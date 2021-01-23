    public class ModelStateEventArgs : EventArgs
    {
        public ModelStateEventArgs(ModelStateDictionary modelState)
        {
            this.ModelState = modelState;
        }
        public ModelStateDictionary ModelState { get; private set; }
    }
