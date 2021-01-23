    public class MyViewModel
    {
        private IOpenDialogService openDialogService;
        // service injected by the IoC
        public MyViewModel(IOpenDialogService openDialogService)
        {
            this.openDialogService = openDialogService;
        }
        public void DoCommand()
        {
            var path = openDialogService.GetOpenDialog("...");
        }
    }
