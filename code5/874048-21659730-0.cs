    foreach (KeyValuePair<string, System.Drawing.Image> item in imageList)
        Task.Factory.StartNew(() =>
        {
            lock (item.Value)
                item.Value.Save(item.Key, System.Drawing.Imaging.ImageFormat.Jpeg);
            
        });
