            var filePath = HttpRuntime.AppDomainAppPath + "your file path";
            if (!File.Exists(filePath))
                return;
            using (var sr = new StreamReader(filePath))
            {
                var text = sr.ReadToEnd();
                if (text.Length < 4 || text.Length > 11)
                {
                    using (var sw = new StreamWriter(filePath))
                    {
                        sw.Write("");
                    }
                }
            }
