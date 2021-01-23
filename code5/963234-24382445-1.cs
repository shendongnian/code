    private string LoadNavigasi(string kodeJabatan)
    {
        if (kodeJabatan == null)
            kodeJabatan = "001";
        DataSet ds = RunQuery("Select KodePosition,NamaPosition,Parent from Position where KodePosition = '" + kodeJabatan + "'");
        var kode = ds.Tables[0].Rows[0][0].ToString();
        var nama = ds.Tables[0].Rows[0][1].ToString();
        var parent = ds.Tables[0].Rows[0][2].ToString();
        string temp = string.Format("<a href=?Kode={0}&Name={1}>{1}</a>", kode, nama);
        if (string.IsNullOrEmpty(parent))
        {
            string tempP = LoadNavigasi(parent);
            temp = string.Format("{1}<ul><li>{0}", temp, tempP);
        }
        return temp;
    }
