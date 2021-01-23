    [TestClass]
    public abstract class AuditableEntityTests {
        protected AuditableEntityTests(IAuditableEntity entity) { Entity = entity; }
        protected IAuditableEntity Entity { get; set; }
        public abstract void GetsAndSetsValue();
        public virtual Throws<TException>(Action action) { 
            // arrange
            Type expected = typeof(TException);
            Exception actual = null;
            // act
            try { action(); } catch(Exception ex) { actual = ex; }
            // assert
            Assert.IsInstanceOfType(actual, expected);
        }
        [TestClass]
        public class CreatedAt : AuditableEntityTests {
            public CreatedAt() : base(new Customer()) { }
            [TestMethod]
            public void GetsAndSetsValue() {
                // arrange
                DateTime expected = DateTime.Now;
                Entity.CreatedAt = expected;
                
                // act
                DateTime actual = Entity.CreatedAt;
                // assert
                Assert.AreEqual(expected, actual);
            }
        }
        [TestClass]
        public class CreatedBy : AutditableEntityTests {
            public CreatedBy() : base(new Customer());
            [TestMethod]
            public void GetsAndSetsValue() {
                // arrange
                string expected = RandomValues.RandomString();
                Entity.CreatedBy = expected;
                // act
                string actual = Entity.CreatedBy;
                // assert
                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            public void CannotBeNull() {
                // arrange 
                string unexpected = null;
                Entity.CreatedBy = RandomValues.RandomString();
                
                // act
                Entity.CreatedBy = unexpected;
                string actual = Entity.CreatedBy;
                // assert
                Assert.IsNotNull(actual);
            }
            [TestMethod]
            public void ThrowsWhenLongerThan12() {
                // arrange
                int length = 256;
                string tooLong = RandomValues.RandomString(length);
                // act
                Action action = () => { Entity.CreatedBy = tooLong; };
                // assert
                Throws<ArgumentOutOfRangeException>(action);
            }
        }
    }
