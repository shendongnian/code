    public void check(string blocknum, string tree) {
        string tre = ddTreeNo.SelectedValue;
        string lstd = "", dtemas = "";
        string str = " select talltree_master.dt_spatheopen ";
        str = str + "  from talltree_master ";
        str = str + " where talltree_master.block_id =" + blocknum + " and talltree_master.dtdied is NULL and talltree_master.talltree_id =" + tree + "";
        OdbcCommand cmd = new OdbcCommand(str, cn);
        try {
            cn.Open();
            OdbcDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                if (dr.IsDBNull(0)) {
                    t1 = "";
                } else {
                    tt = dr.GetDate(0);
                    lstd = tt.ToShortDateString();
                }
            }
        } catch (Exception ex) {
            Response.Write(ex);
        } finally {
            cn.Close();
        }
        string block_id = lstd;
        hBlockID.Value = block_id.ToString();
        dtActv.Text = block_id.ToString();
    }
