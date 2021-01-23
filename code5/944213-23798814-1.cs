    <asp:LinkButton ID="LinkButton1" runat="server" Text="Upload" CommandName="Upload"
                            CommandArgument='<%#Eval("StudentID")%>'></asp:LinkButton>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Upload")
        {
            // get student id against clicked link button
            int studentid = Convert.ToInt16(e.CommandArgument);
            // -- set status in database it is clicked
        }
    }
 
