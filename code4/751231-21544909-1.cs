      {
       try
       {
        if (RemarkTextBox.Text == string.Empty)
        {
            BRMessengers.BRInformation(this, "Remarks Cannot Be left Empty.");
            return;
        }
        else
        { 
          if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                deleteReport(id);
            }
       }
    }
    catch(Exception)
    {
     BrMessanger.BrMessage(this,"server error. Please try again");
    }
    finally
    {
      YourGridName.DataSource=loadDetails();
      YourGridName.DataBind();
    }
    }
