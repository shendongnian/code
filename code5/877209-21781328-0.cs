    public class Controller {
        private readonly IResolutionRoot resolutionRoot;
        public Controller(IResolutionRoot resolutionRoot) {
            this.resolutionRoot = resolutionRoot;
        }
        public void SendEmail() {
            this.resolutionRoot.Get<IEmail>().Send();
        }
    }
