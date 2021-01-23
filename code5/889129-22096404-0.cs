    string s;
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GridViewRow gr = ((sender as LinkButton).NamingContainer as GridViewRow);
        //string s = gr.Cells[0].Text.Trim();
    s += gr.Cells[0].Text.Trim() + ";";
    }
