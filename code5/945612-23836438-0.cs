    SqlCeCommand sql3 = new SqlCeCommand("SELECT (ACM_EMPL.NUM_EMPL + '~' + ACM_EMPL.NOM_EMPL) AS NUM_EMPL FROM ACM_EMPL INNER JOIN ACM_ACT ON ACM_EMPL.NUM_EMPL = ACM_ACT.NUM_EMPL WHERE (ACM_ACT.NUM_ACTIVO = '" + oc.Text + "'AND ACM_ACT.NUM_CIA = '" + CIA.Text + "' AND ACM_ACT.NUM_TIPO = '" + TIPO.Text + "' AND ACM_ACT.SUB_NUM_ACT = '" + SUBNUM.Text + "') ", conn);
        sql3.ExecuteNonQuery();
        SqlCeDataAdapter cb3 = new SqlCeDataAdapter(sql3);
        DataTable dt3 = new DataTable();
        cb3.Fill(dt3);
        foreach (DataRow dr3 in dt3.Rows)
        {
            ma.cmbEmpleado.Items.Add(dr3["NUM_EMPL"].ToString());
        }
        ma.cmbEmpleado.Items.Insert(0, "------------");
        ma.cmbEmpleado.SelectedIndex = 0;
        cb3.Dispose();
        dt3.Dispose();
