    using Microsoft.Deployment.WindowsInstaller;
    using(Database database = new Database(PATH_TO_MSI, DatabaseOpenMode.ReadOnly))
    {
      Console.WriteLine(database.SummaryInfo.Template);
    }
