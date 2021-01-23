    if (newItem.FieldType == FormFieldType.Signature)
    {
        if (newItem.ItemValue != null)
        {
            //string completeImageName = Auth.host + "/" + li[i];
            string path;
            string filename;
            string stringName = newItem.ItemValue;
    
            var base64Data = Regex.Match(stringName, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
    
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
            //filename = Path.Combine(path, base64Data.Replace(@"/", string.Empty));
    
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            string fileName = "Sn" + milliseconds.ToString() + ".PNG";
            filename = Path.Combine(path, fileName);
    
            if (!File.Exists(filename))
            {
                //using (var stream = new MemoryStream(binData))
                //{
                    File.WriteAllBytes(filename, binData);
                //}
            }
    
            newItem.ItemValue = filename;
    
        }
    }
    
    App.Database.SaveReportItem(newItem);
