    private void button1_Click(object sender, EventArgs e)
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='d:\\testing file\\list.xls';Extended Properties= \"Excel 8.0;HDR=Yes;IMEX=1\";");
        OleDbDataAdapter da = new OleDbDataAdapter("select * from [List$]", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string str = dt.Rows[i][0].ToString();
            rows.Add(str);
        }
        webBrowser1.NavigateTo(fillAddress);
    }
