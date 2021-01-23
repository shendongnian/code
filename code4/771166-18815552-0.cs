      public class MobileDisplay : DefaultDisplayMode
      {
        public MobileDisplay()
          // postfix of the file
          : base("mobile")
        {
          // create an expression if the current postfix is applicatble
          ContextCondition = context => context.Request.Browser.IsMobileDevice;
        }
      }
