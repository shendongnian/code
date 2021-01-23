    public Result OnStartup(UIControlledApplication application)  {
         application.ControlledApplication.DocumentOpened += OnDocOpened;
         //Rest of your code here...
         return Result.Succeeded;
    }
    private void OnDocOpened(object sender, DocumentOpenedEventArgs args) {
        Autodesk.Revit.ApplicationServices.Application app = (Autodesk.Revit.ApplicationServices.Application)sender;
        Document doc = args.Document;
        //Your code here...
    }
