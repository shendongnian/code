    protected void btnread_Click(object sender, EventArgs e)
    {
        int index, aid;
               
    
        if (int.TryParse(txtindex.Text, out index))
        {
            // Index is 0 based, but we input row number from 1
            // So we have to sutract 1 from input
            index--;
    
            if ((index >= 0) && (index <= gvinbox.DataKeys.Count) && (int.TryParse((gvinbox.DataKeys[index].Value.ToString()), out aid))
            {
                Response.Redirect(string.Format("Showmessage.aspx?MessageNumber={0}", aid));
            }
            else
            {
                // Input out of range
                // Do whatever to display error
            }
        }
    }
