    private void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        switch (e.CommandName) {
            case "lnkAttachmentClick":
                int document_id = (int)e.CommandArgument;
                // Write your code here
                break;
    }
