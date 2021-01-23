        public static void CreateBatch(int batchSize)
        {
            string sourcePath = @"C:\Users\hari\Desktop\test";
            var pdfs = Directory.EnumerateFiles(sourcePath, "*.pdf", SearchOption.TopDirectoryOnly);
            var tiffs = Directory.EnumerateFiles(sourcePath, "*.tiff", SearchOption.TopDirectoryOnly);
            var images = pdfs.Union(tiffs);
            var imageGroups = from image in images
                              group image by Regex.Replace(Path.GetFileNameWithoutExtension(image), @"_\d+$", "") into g
                              select new { GroupName = g.Key, Files = g.OrderBy(s => s) };
            List<List<string>> batches = new List<List<string>>();
            List<string> batch = new List<string>();
            foreach (var group in imageGroups)
            {
                batch = batch.Union(group.Files).ToList<string>();
                if (batch.Count >= batchSize)
                {
                    batches.Add(batch);
                    batch = new List<string>();
                }
            }            
        }
