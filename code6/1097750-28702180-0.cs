    public partial class MyViewController : GenericViewController //inherits from UIViewController 
    {
      .....
     public async override void ViewDidLoad()
     {
            try
            {
                base.ViewDidLoad();
                //other irrelevant code here
                throw new Exception("Something went wrong");
            }
            catch (Exception ex)
            {
                int actionCode = await AlertViewControllerHelper.ShowAlertDialogAsync(ParentViewController, AlertViewControllerHelper.ERRORDESCRIPTION);
                if (actionCode == AlertViewControllerHelper.INFOACTIONCODE)
                {
                    await AlertViewControllerHelper.ShowAlertDialogAsync(ParentViewController, string.Format("{0} : {1}", ex.Message, ex.StackTrace), actionCode);
                }
            }   
     }  
      ........
    }
