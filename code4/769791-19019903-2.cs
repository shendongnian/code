    protected void btnAddCopy_Click(object sender, EventArgs e)
        {
          for (int i = 0; i < gvTrip.Rows.Count; i++)
                    {
                            string strTripDate = DateValidator.ConvertToMMDDYYYY(txtCopyTripDt.Text).ToString();
                            string strRouteSlcn = Convert.ToString(((Label)gvTrip.Rows[i].FindControl("lblgRouteSlcn2")).Text.Trim());
                            string strTripStartTime = Convert.ToString(((Label)gvTrip.Rows[i].FindControl("lblgTripStartTime")).Text.Trim());
                            string strTripEndTime = Convert.ToString(((Label)gvTrip.Rows[i].FindControl("lblgTripEndTime")).Text.Trim());
                            objMasterTransport.**insertTripDetail**(strTripDate, strRouteSlcn, strTripStartTime, strTripEndTime);
    objMasterTransport.**YourFunctionForGenWordFile**(strTripDate, strRouteSlcn, strTripStartTime, strTripEndTime);
                        txtCopyTripDt.Text = null;
                        gvTrip.DataBind();
                        BindData();
           }
        }
