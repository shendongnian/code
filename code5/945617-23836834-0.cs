                SqlCeCommand sql3 = new SqlCeCommand("SELECT (ACM_EMPL.NUM_EMPL + '~' + ACM_EMPL.NOM_EMPL) AS NUM_EMPL FROM ACM_EMPL INNER JOIN ACM_ACT ON ACM_EMPL.NUM_EMPL = ACM_ACT.NUM_EMPL WHERE (ACM_ACT.NUM_ACTIVO = '" + oc.Text + "'AND ACM_ACT.NUM_CIA = '" + CIA.Text + "' AND ACM_ACT.NUM_TIPO = '" + TIPO.Text + "' AND ACM_ACT.SUB_NUM_ACT = '" + SUBNUM.Text + "') ", conn);
            sql3.ExecuteNonQuery();
            SqlCeDataAdapter cb3 = new SqlCeDataAdapter(sql3);
            DataTable dt3 = new DataTable();
            cb3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
               
                ma.cmbEmpleado.DataSource = dt;
                ma.cmbEmpleado.DataValueField = dt3.Columns["NUM_EMPL"].ToString();
                ma.cmbEmpleado.DataTextField = dt3.Columns["NUM_EMPL"].ToString();
            }
            ma.cmbEmpleado.Items.Insert(0, "---------");
            ma.cmbEmpleado.Items[0].Value = "0";
