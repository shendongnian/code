    public class LargeJsonResult : JsonResult
    {
        public LargeJsonResult()
            : base()
        {
            this.MaxJsonLength = Int32.MaxValue;
        }
    }
