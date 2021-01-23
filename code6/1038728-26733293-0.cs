    Task.Factory.StartNew(() =>
    {
          WebClient webc = new WebClient();
          webc.DownloadFile(dataGridView1.Rows[i].Cells[0].Value.ToString(), patch + "\\" + "alap" + (i+1).ToString() + ".mp4");
    });
