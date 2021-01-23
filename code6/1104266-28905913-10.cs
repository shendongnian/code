    public class ManhattanProject
    {
        private readonly IMessageBox messageBoxService;
        private readonly IEnumerable<IProjectSubPart> parts;
        public ManhattanProject(IMessageBox messageBoxService, 
            IEnumerable<IProjectSubPart> parts) {
            this.messageBoxService = messageBoxService;
            this.parts = parts;
        }
        public void RunProject() {
            messageBoxService.ShowMessage("Project started...");
            
            var calculationResults =
                from pair in parts.Select((part, index) => new { part, value = index + 1 })
                select pair.part.DoCalculations(pair.value);
                
            var result = calculationResults.Sum();
            messageBoxService.ShowMessage(
                string.Format("Project finished with magic result {0}", result));
        }
    }
