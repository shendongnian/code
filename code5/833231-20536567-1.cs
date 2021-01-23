    public static class ZarettoContextExtensionClass
    {
        public static tblTest Reload(this tblTest item, DbContext c)
        {
            c.Configuration.AutoDetectChangesEnabled = false;
            c.Entry(item).Reload();
            c.Configuration.AutoDetectChangesEnabled = true;
            return item;
        }
    }
