    public class AccessProcessHandlerDecorator<TProcess> : IProcessHandler<TProcess> {
        private readonly IProcessHandler<TProcess> decoratee;
        private readonly IPrincipal userContext;
        public AccessProcessHandlerDecorator(IProcessHandler<TProcess> decoratee,
            IPrincipal userContext) {
            this.decoratee = decoratee;
            this.userContext = userContext;
        }
        public void Handle(TProcess process) {
            string user = this.userContext.Identity.Name;
            // access control
            this.decoratee.Handle(process);
        }
    }
