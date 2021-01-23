    protected void RefreshSmsComplaints_Tick(object sender, EventArgs e)
    {
       try
       {
          DateTime fromDate = DateTime.ParseExact(txtFromDate.Text, "dd/MMM/yyyy", null);
          DateTime toDate = DateTime.ParseExact(txtToDate.Text, "dd/MMM/yyyy", null);
          DataTable dt = ManageRecievedMessage.GetSmsComplaintsByDate(fromDate, toDate);
          //GridViewSmsComplaints.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
    
          if(dt.Rows.Count > 0)
          {
             GridViewSmsComplaints.DataSource = dt;
             GridViewSmsComplaints.DataBind();
             GridViewSmsComplaints.Visible = true;
             //gridViewComplaintsBySubject.Visible = false;
          }
          else
          {
             dt.Rows.Add(dt.NewRow());
             GridViewSmsComplaints.DataSource = dt;
             GridViewSmsComplaints.DataBind();
             int totalcolums = GridViewSmsComplaints.Rows[0].Cells.Count;
             GridViewSmsComplaints.Rows[0].Cells.Clear();
             GridViewSmsComplaints.Rows[0].Cells.Add(new TableCell());
             GridViewSmsComplaints.Rows[0].Cells[0].ColumnSpan = totalcolums;
             GridViewSmsComplaints.Rows[0].Cells[0].Text = "No Data Found for this date combination";
             GridViewSmsComplaints.Visible = true;
             //gridViewComplaintsBySubject.Visible = false;
          }
       }
       catch
       {
          // Handle Exception
       }
    }
