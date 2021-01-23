    dt.Columns.Add("Picture", typeof(byte[]));
    System.Net.WebClient client = new System.Net.WebClient();
    int i = 0;
    client.DownloadDataAsync(new Uri(dt.Rows[0].Field<string>("brandPic")), dt.Rows[0]);
    client.DownloadDataCompleted += (se, e) => {
       ((DataRow)e.UserState).SetField<byte[]>("Picture", e.Result);
       if(++i == dt.Rows.Count) return;               
       client.DownloadDataAsync(new Uri(dt.Rows[i].Field<string>("brandPic")), dt.Rows[i]);
    };            
    dt.Columns.Remove("brandPic");
    dgv.DataSource = dt;
