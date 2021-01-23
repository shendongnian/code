            var pc = new ParserContext
            {
                BaseUri = new Uri(runtimeResourcesDirectory , UriKind.Absolute)
            };
            ...
            using (Stream s = File.Open(resourceDictionaryFile, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    var resourceDictionary = XamlReader.Load(s, pc) as ResourceDictionary;
                    if (resourceDictionary != null)
                    {
                        Resources.MergedDictionaries.Add(resourceDictionary);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid xaml: " + resourceDictionaryFile);
                }
            }
        }
