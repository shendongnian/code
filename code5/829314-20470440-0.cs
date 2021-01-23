        public class QSDPrincipal : WindowsPrincipal
        {
            private readonly IUserService userService;
        
            public QSDPrincipal(WindowsIdentity ntIdentity,
                IUserService userService) :
                base(ntIdentity)
            {
                this.userService = userService;
            }
            public override bool IsInRole(string role)
            {
                return userService.CurrentUserIsInRole(role);
            }
        }
