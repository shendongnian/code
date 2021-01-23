    public class Stepper
    {
        private int StepNumber { get; set; }
        
        public void Step(string description, Action code)
        {
            StepNumber++;
            try
            {
                code();
            }
            catch (Exception ex)
            {
                Assert.Fail(AppManager.RaiseError(StepNumber, description, ex));
            }
        }
    }
