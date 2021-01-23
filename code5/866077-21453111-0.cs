    private void toolStripJSONLoad_Click(object sender, EventArgs e)
    {
        string tmp = File.ReadAllText(@"D:\path.txt", Encoding.UTF8);
    
        JavaScriptSerializer oSerializer = new JavaScriptSerializer();
        var tmpObj = oSerializer.Deserialize<List<BackupItem>>(tmp);
        bb.Clear();
        tmpObj.ForEach(o => bb.Add(o));
    }
