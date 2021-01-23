            while (entries.Count > 0)
            {
                service.InsertEntries(entries.Take(100).ToList<Entry>());
                entries = entries.Skip(100);
                System.Threading.Thread.Sleep(5000);
            }
