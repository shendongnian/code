    public IDialogService DialogService
    {
        get
        {
            return dialogServiceProvider.ProvideService();
        }    
       set
        {
            dialogServiceProvider.SetNewService(value);
        }
    }
    public class DialogServiceProvider()
    {
         public DialogServiceProvider(IDialogService service)
         {
              //save the dialog service
         }
    
         public ProvideService(){ //return it }
    
         public SetNewService(IDialogService newService){//overwrite existing reference}
    }
