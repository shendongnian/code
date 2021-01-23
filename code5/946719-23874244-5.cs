    [TestClass]
    public class BehaviorsFixture {
        #region Setup
        private Mock<IEnvironment> _mockEnvironment;
        private Rabbit CreateRabbit() {
            var buggs = new Rabbit(_mockEnvironment.Object);
            buggs.RegisterBehaviour(Behaviors.Jump, r => r.XVal += 10);
            // gravity GTE 30, cannot jump
            buggs.RegisterBehaviorModifier(Behaviors.Jump, (e, o) => e.Gravity >= 30);
            // gravity GTE 20, (but LT 30), jumps 5
            buggs.RegisterBehaviorModifier(Behaviors.Jump, (e, o) => e.Gravity >= 20, r => r.XVal += 5);
            // if the rabbit is frozen it cannot jump
            buggs.RegisterBehaviorModifier(Behaviors.Jump, (e, o) => o.IsInState(States.Frozen));
            // if the rabbit is chilled it can only jump 2
            buggs.RegisterBehaviorModifier(Behaviors.Jump, (e, o) => o.IsInState(States.Chilled), r => r.XVal += 2);
            return buggs;
        }
        #endregion
        [TestInitialize]
        public void TestInitialize() {
        _mockEnvironment = new Mock<IEnvironment>();
        _mockEnvironment.SetupProperty(mk => mk.Gravity, 9.81);
        }
        [TestMethod]
        public void JumpingInGravity() {
            var buggs = CreateRabbit();
            Assert.AreEqual(0, buggs.XVal);
            buggs.Invoke(Behaviors.Jump);
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(20, buggs.XVal);
            // higher gravity means can only jump 5
            _mockEnvironment.Object.Gravity = 20.0;
            buggs.Invoke(Behaviors.Jump);
			
            Assert.AreEqual(25, buggs.XVal);
            // even higher gravity, cannot jump
            _mockEnvironment.Object.Gravity = 30.0;
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(25, buggs.XVal);
            // set gravity back to normal - can jump
            _mockEnvironment.Object.Gravity = 9.81;
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(35, buggs.XVal);
        }
        [TestMethod]
        public void JumpingWhenCold() {
            var buggs = CreateRabbit();
            Assert.AreEqual(0, buggs.XVal);
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(10, buggs.XVal);
			
            // if frozen, cannot jump
            buggs.SetState(States.Frozen);
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(10, buggs.XVal);
            // remove, can jump again
            buggs.ClearState(States.Frozen);
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(20, buggs.XVal);
            // if chilled, can jump a bit
            buggs.SetState(States.Chilled);
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(22, buggs.XVal);
            // remove, can jump again
            buggs.ClearState(States.Chilled);
            buggs.Invoke(Behaviors.Jump);
            Assert.AreEqual(32, buggs.XVal);
            }
        }
    }
