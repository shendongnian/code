    public static List<MyCatalogViewModel> LoadCatalog<T>()
        where T : class, ICatalogItem
    {
       var catalog= DbContext.Set<T>.Where(t => !t.Deleted).Select(k=> new MyCatalogViewModel{ Id= k.Id, Name = k.Name}).ToList();
       return catalog;
    }
