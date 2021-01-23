    public class ErrorHandlerExtention: BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(MyErrorHandlingBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new MyErrorHandlingBehavior();
        }
    }
      
