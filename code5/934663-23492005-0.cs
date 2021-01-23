    public partial class App : Application
    {
        ~App()
        {
            Administration.Model.DataBaseModel.GlobalCatalogue.ToFile();
        }
    }
