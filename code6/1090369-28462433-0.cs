    public class YourController
    {
        static Signal _errorsignal = Signal.Create("YourController.Error");
    
        public ActionResult SomeAction()
        {
            try
            {
                //some logic
               
                //logic succeeded, reset
                _errorSignal.Reset();
            }
            catch (Exception ex) 
            { 
                //Raised for the first time, notify
                if (_errorSignal.Raise(ex))
                    HandleError(ex); 
                return RedirectToAction("Index", "Error"); 
            }
    
        //[...]
    }
