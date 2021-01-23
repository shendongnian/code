    public abstract class Given_An_Engine {
        protected Engine _engine;
        [SetUp]
        public void GivenAnEngine() {
            _engine = new Engine();
        }
        public abstract class That_Is_Stopped : Given_An_Engine {
            [SetUp]
            public void ThatIsStopped() {
                _engine.State = STOPPED;
            }
            public class When_I_Open_The_Status_UI : That_Is_Stopped {
                public StatusUI _ui; // You'll learn better ways than making _ui public. This is just for shortness.
                [SetUp]
                public void WhenIOpenTheStatusUI() {
                  _ui = _engine.OpenUI();
                }
                [TestFixture]
                public class Behaves_Like_Display_Of_Stopped_Engine
                    : Behaves_Like_Display_Of_Stopped_Engine<When_I_Open_The_Status_UI> {}
            }
        }
    }
    public class Behaves_Like_Display_Of_Stopped_Engine<TContext> 
        where TContext: Given_An_Engine.That_Is_Stopped.When_I_Open_The_Status_UI, new() {
        TContext ctx = new TContext();
        [SetUp]
        public void SetUp() {
            ctx.RunSetUp();
        }
        [TearDown]
        public void TearDown() {
            ctx.RunTearDown();
        }
        [Test]
        public void Displays_Stopped() {
           Assert.AreEqual("Stopped", ctx._ui.lblStatus.Text);
        }
        [Test]
        public void Displays_A_Red_Lamp() {
           Assert.AreEqual(Color.Red, ctx._ui.LampColor);
        }
    }
