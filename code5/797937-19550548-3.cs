    System.Net.WebClient client = new System.Net.WebClient();
    client.DownloadDataCompleted += (s,e) => {
       ((DataRow) e.UserState).SetField<byte[]>("Picture", e.Result);
    };
    private void LoadBytesFromImageURLAsync(DataRow row, string url){
      client.DownloadDataAsync(new Uri(url), row);
    }
    foreach(DataRow row in dt.Rows){
      LoadBytesFromImageURLAsync(row, row.Field<string>("brandPic"));
    }
    dt.Columns.Remove("brandPic");
    dgv.DataSource = dt;
