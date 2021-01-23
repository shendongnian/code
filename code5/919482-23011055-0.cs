            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                var bytes = File.ReadAllBytes(@"e:\scripts_04-10-2014.zip");
                var zipAsBase64 = Convert.ToBase64String(bytes);
    
                foreach (var item in GetUnzippedItemsAsStream(zipAsBase64))
                {
                    using (var fs = new FileStream(Path.Combine(@"e:\", item.Item1), FileMode.CreateNew,
                            FileAccess.ReadWrite))
                    {
                        item.Item2.CopyTo(fs);
                    }
                }
            }
    
            public IEnumerable<Tuple<string, Stream>> GetUnzippedItemsAsStream(string stringBase64Zipped)
            {
                var bytesZipFile = Convert.FromBase64String(stringBase64Zipped);
                using (var ms = new MemoryStream(bytesZipFile))
                {
                    using (var zipFile = ZipFile.Read(ms))
                    {
                        foreach (var zipEntry in zipFile.Entries)
                        {
                            var outputStream = new MemoryStream();
                                zipEntry.Extract(outputStream);
                                yield return new Tuple<string, Stream>(zipEntry.FileName, new MemoryStream(outputStream.ToArray()));
                        }
                    }
                }
            }
