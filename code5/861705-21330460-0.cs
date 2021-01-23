    var mapping = Microsoft.Win32.Registry.ClassesRoot.GetSubKeyNames()
                   .Select(key => new
                    {
                        Key = key,
                        ContentType = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(key).GetValue("Content Type")
                    })
                    .Where(x => x.ContentType != null)
                    .ToLookup(x => x.ContentType, x => x.Key);
    Console.WriteLine(String.Join(";",mapping["image/jpeg"]));
