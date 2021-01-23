    class Program
    {
        static void Main(string[] args)
        {
            COMAdminCatalog catalog = new COMAdminCatalog();
            COMAdminCatalogCollection applications = catalog.GetCollection("Applications");
            applications.Populate();
            for (int i = 0; i < applications.Count; i++)
            {
                COMAdminCatalogObject application = applications.Item[i];
                Console.WriteLine(application.Name);
                Console.WriteLine(application.Value["Identity"]);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
