    protected void BtnSaveAttendence_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow Gr in GridView1.Rows)
        {
         TextBox txt = (TextBox)(Gr.FindControl("TotalTime"));
         txt.ReadOnly = false;
        }
        int Rest = new int();
        object[] objAttnd = new object[8];
        foreach (GridViewRow GR in GridView1.Rows)
        {
            objAttnd[0] = 0;
            objAttnd[1] = ((Label)GR.FindControl("LblEMPNAME")).Text;
            objAttnd[2] = UserInfo.Company.CompanyID;
            objAttnd[3] = Common.Convert_MM_DD_YYYY(txtDate1.Text);
            objAttnd[4] =((TextBox)GR.FindControl("InTime")).Text;
            objAttnd[5] =((TextBox)GR.FindControl("OutTime")).Text;
            objAttnd[6] = ((TextBox)GR.FindControl("TotalTime")).Text;                
            objAttnd[7] = Convert.ToDecimal(((Label)GR.FindControl("LblEmpCode")).Text);
          /*ForEach from Here to*/
         Rest = objAttendance.InsertUpdateAttendenceDetailNew(objAttnd);
        }
      /*===>here*/
        foreach (GridViewRow Gr in GridView1.Rows)
        {
            TextBox txt = (TextBox)(Gr.FindControl("TotalTime"));
            txt.ReadOnly = true;
        }
        if (Rest == -1)
        {
            lblError.Text = "<div class='ErrorMsg'> Attendance details already added for Selected date !!</div>";
        }
    }
