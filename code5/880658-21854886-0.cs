    protected void btnAdd_Click(object sender, EventArgs e)
     {
     DataTable dt = new DataTable();
        dt = defineColumn();
        DataRow dr;
        foreach (GridViewRow grow in grdChMedicine.Rows)
        {
            dr = dt.NewRow();
            dr["Diagnosis"] = grow.Cells[1].Text;
            dr["DiagnosisId"] = grow.Cells[2].Text;
            dt.Rows.Add(dr);
        }
        dr = dt.NewRow();
      
        dr["Diagnosis"] = ddldiagnosis.SelectedItem.ToString();
        dr["DiagnosisId"] = ddldiagnosis.SelectedValue;
        dt.Rows.Add(dr);
      
        ViewState["ChMedicine"] = dt;
        grdChMedicine.DataSource = dt;
        grdChMedicine.DataBind();
   
       }
    private DataTable defineColumn()
    {
        DataTable dt = new DataTable();
       
        dc = new DataColumn("Diagnosis");
        dt.Columns.Add(dc);
        dc = new DataColumn("DiagnosisId");
        dt.Columns.Add(dc);
        return dt;
    }
