    if (
           dt.Rows.Count()>0 && 
           (
               dt.Rows[0]["pagestatusid"].ToString() == "3" || 
               dt.Rows[0]["pagestatusid"].ToString() == "0" || 
               (
                   dt.Rows[0]["expirydate"] != DBNull.Value && 
                   DateTime.Parse(dt.Rows[0]["expirydate"].ToString()) < DateTime.Now
               )
           )
       )
    {
        pnlDraftWarning.Visible = false;
        pnlContentNotAvailable.Visible = true;
        pnlMainContent.Visible = false;
        Response.StatusCode = 404;
        return;
    }
