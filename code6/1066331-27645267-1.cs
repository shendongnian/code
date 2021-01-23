    private void childclick(object sender, EventArgs e)
    {
        DataTable dtTrans = new DataTable();
        dtTrans = Db.bindData("SELECT frm_Code FROM tbl_MST_SubMnu WHERE frm_Name='" + sender.ToString() + "'");
        Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
        foreach (Type type in frmAssembly.GetTypes())
        {
            if (type.BaseType == typeof(Form))
            {
                if (type.Name == dtTrans.Rows[0][0].ToString())
                {
                    Form frmshow = (Form)frmAssembly.CreateInstance(type.ToString());
                    frmshow.Show();
                }
            }
        }
    }
