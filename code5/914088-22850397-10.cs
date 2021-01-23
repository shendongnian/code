    public List<ImageInfo> ReadImageInfos(string fileName)
    {          
        string[] records = File.ReadAllLines(fileName);
        var images = new List<ImageInfo>(records.Length);
        foreach (string record in records) {
            string[] columns = record.Split(',');
            if (columns.Length >= 5) {
                var imageInfo = new ImageInfo();
                imageInfo.FileName = columns[0];
                imageInfo.Description = columns[1];
                imageInfo.Category = columns[2];
                
                DateTime d;
                if (DateTime.TryParseExact(columns[3], "dd/MM/yy", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                {
                    imageInfo.Date = d;
                }
                
                imageInfo.Comments = columns[4];
                
                images.Add(imageInfo);
            }
        }
        return images;
    }
