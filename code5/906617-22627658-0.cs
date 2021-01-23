     private ISQLiteConnection CreateFileDb(SQLiteConnectionOptions options)
            {
                if (string.IsNullOrWhiteSpace(options.Address))
                    throw new ArgumentException(Properties.Resources.CreateFileDbInvalidAddress);
                var path = options.BasePath ?? GetDefaultBasePath();
                string filePath = LocalPathCombine(path, options.Address);
                return CreateSQLiteConnection(filePath, options.StoreDateTimeAsTicks);
            }
