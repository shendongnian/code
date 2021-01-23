        public const int CURRENT_VERSION = 2;
        public static DocumentOpen(string path)
        {
            var controller = new DocumentController();
            var item = controller.ReadXml(path);
            if (item.Version != CURRENT_VERSION)
            {
                var migrator = new DocumentMigrator(item, path);
                migrator.MigrateToLatestVersion();
            }
            return item;
        }
