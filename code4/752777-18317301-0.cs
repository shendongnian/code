    public class TesterController : YourController
    {
        public new ActionResult MyFunction(string inputData, MediaJsonResult result)
        {
            return base.MyFunction(inputData, result);
        }
    }
