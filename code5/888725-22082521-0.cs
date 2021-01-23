    public class TestServiceThatAlwaysReturnFalseForCheckBoolean : Service
    {
        public void CheckService()
        {
            base.CheckService()
        }
    
        public override bool Getboolean()
        {
            return false;
        }
    }
