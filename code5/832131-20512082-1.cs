    public class WantToTestThis : CanNeverChange
    {
        protected override void ThisVaries()
        {
             new TestableClass().DoSomethingYouWantToTest();
        }
    }
    public class TestableClass
    {
        public void DoSomethingTestable()
        {
            //do something you want to test here instead, where you can test it
        }
    }
