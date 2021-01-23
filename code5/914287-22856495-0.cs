    <asp:TemplateField>
        <ItemTemplate>
            <asp:Label ID="labelResult" runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
           string value = e.Row.Cells[0].Text;
           Next find the label in the template field.
            Label myLabel = (Label) e.Row.FindControl("myLabel");
            if (value == "N")
            {
                myLabel.Text = "New";
            }
            else if (value == "V")
            {
                myLabel.Text = "Verified";
            }
            else if (value == "C")
            {
                myLabel.Text = "Cancelled";
            }
            else if (value == "D")
            {
                myLabel.Text = "Deleted";
            }
        }
    }
