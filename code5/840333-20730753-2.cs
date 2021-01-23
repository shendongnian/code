    public class AccessProcessHandlerDecorator<TProcess> 
        : IProcessHandler<AccessMessage<TProcess>>
    {
        private readonly IProcessHandler<AccessMessage<TProcess>> decoratee;
        private readonly IPrincipal userContext;
        public AccessProcessHandlerDecorator(
            IProcessHandler<AccessMessage<TProcess>> decoratee,
            IPrincipal userContext) {
            this.decoratee = decoratee;
            this.userContext = userContext;
        }
        public void Handle(AccessMessage<TProcess> process) {
            string user = this.userContext.Identity.Name;
            // access control
            this.decoratee.Handle(process);
        }
    }
