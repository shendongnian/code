    <asp:GridView ID="gvChild" ... DataKeyNames="CityID">
      <Columns>
        ...
        <asp:TemplateField>
          <ItemTemplate>
            <asp:LinkButton ID="lnkSelectedCity" 
               ...
               CommandArgument='<%# Eval("CityID") %>' 
               ToolTip="Select x" />
          </ItemTemplate>
        </asp:TemplateField>
    protected void gvChild_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "ShowDetails")
      {
        int cityId = Convert.ToInt32(e.CommandArgument);
      }  
    }  
