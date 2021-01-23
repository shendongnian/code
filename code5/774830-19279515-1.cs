    private void BindData()
    {
        DataSet ds = LoadXml();
        GridView1.DataSource = ds.Tables["DocType"];
        GridView1.DataBind();
        DataRow r = ds.Tables["Study"].Rows[0];
        chkDocumentView.Checked = bool.Parse(r[1].ToString());
        chkColumnarView.Checked = bool.Parse(r[2].ToString());
    }
