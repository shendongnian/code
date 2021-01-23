    public class Example
    {
        private List<string> TestModes;
    
        public Example()
        {
            try
            {
               SetMode();
               TestModes = new List<string>();
            }
            catch (Exception e)
            {                
                throw;
            }
        }
    
        public void SetMode()
        {
            TestModes.Add("This is a test mode");
        }
    }
