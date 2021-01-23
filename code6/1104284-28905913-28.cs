    public class MessageBoxLoggingProjectSubPart : IProjectSubPart
    {
        private readonly IMessageBox messageBoxService;
        private readonly IProjectSubPart decoratee;
        
        public MessageBoxLoggingProjectSubPart(IMessageBox messageBoxService,
            IProjectSubPart decoratee) {
            this.messageBoxService = messageBoxService;
            this.decoratee = decoratee;
        }
    
        public int DoCalculations(int myParam) {
            messageBoxService.ShowMessage("Hardly working 1...");
            
            return this.decoratee.DoCalculations(myParam);
        }
    }
	
