    CustomConfig.Section c = ConfigurationManager.GetSection("PrintLogPurgeSettings") as CustomConfig.Section;
    foreach (CustomConfig.Element element in c.PrintLogPurgeSettings.Cast<CustomConfig.Element>())
    {
        Console.WriteLine("{0}:{1}", element.Level, element.DaysAged);
    }
