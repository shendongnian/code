            string tempFile = string.Format("{0}\\{1}", System.IO.Path.GetTempPath(), "System.Data.SQLite.dll");
            System.IO.File.WriteAllBytes(tempFile, System.IO.File.ReadAllBytes(@"C:\System.Data.SQLite_x64.dll"));
            var assembly = Assembly.LoadFile(tempFile);
            Type t = assembly.GetExportedTypes()[8];
            object sqliteCon = Activator.CreateInstance(t, @"Data Source=d:\nwind.db;Version=3;");  
