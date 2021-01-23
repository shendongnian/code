    [TestClass]
    public abstract class BetterBase : Base {
        public BetterBase() {
            AddSetUpAction(SetUp);
            AddTearDownAction(TearDown);
        }
        private static void SetUp() { //BetterBase setup actions }
        private static void TearDown() { //BetterBase teardown actions }
    }
    [TestClass]
    public abstract class EvenBetterBase : BetterBase {
        public EvenBetterBase() {
            AddSetUpAction(SetUp);
            AddTearDownAction(TearDown);
        }
        private static void SetUp() { //EvenBetterBase setup actions }
        private static void TearDown() { //EvenBetterBase teardown actions }
    }
