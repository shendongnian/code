    protected void gvTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (condition)
        {                   
            StringBuilder sb = new StringBuilder();
            // Using function pageLoad() to execute the script 
            // whenever the page is fully or partially loaded (AJAX).
            sb.Append("function pageLoad() {");
            sb.Append("alert('");
            sb.Append("The following item has been chosen by another user. Please choose another one. \\n\\n" + row.Cells[3].Text + "\\n");
            sb.Append("')}");
            // UpdatePanel1 needs to be replaced with your UpdatePanel ID.
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "alert", sb.ToString(), true);
        }
    }
