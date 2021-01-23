    public class FileHandler : IHttpHandler
        {
            private readonly IAccountService _accountService;
            private readonly IAttachmentService _attachmentService;
            
            public FileHandler()
            {
            }
            public FileHandler(IAccountService accountService, IAttachmentService attachmentService)
            {
                _accountService = accountService;
                _attachmentService = attachmentService;
            }
        
          ....
        }
