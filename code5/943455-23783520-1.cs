    using (EntitiesModel dbContext = new EntitiesModel())
    {
        IQueryable<Category> cats = dbContext.Categories;
        string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string fileLocation = Path.Combine(appDir, "test.csv");
        EntitiesExporter.ExportEntityList<Category>(fileLocation, cats);
    }
 
