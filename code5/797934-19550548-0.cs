    dt.Columns.Add("Picture", typeof(byte[]));
    var actualData = dt.AsEnumerable()
                       .Select(row=> {
                           row.SetField<byte[]>("Picture", GetBytesFromImagePath(row.Field<string>("brandPic"));
                           return row;
                        }).CopyToDataTable();
    actualData.Columns.Remove("brandPic");
    dgv.DataSource = actualData;
    
    //Use this method to get byte[] data from the image path
    private byte[] GetBytesFromImagePath(string imagePath){
       using(MemoryStream ms = new MemoryStream()){
         Image img = Image.FromFile(imagePath);
         img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
         return ms.GetBuffer();
       }
    }
