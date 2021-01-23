    you can use Commandname property like this for button of nested repeater-
     <asp:Repeater ID="rprSSNested" runat="server" OnItemCommand="rprSSNested_ItemCommand" >  
                    <HeaderTemplate>
                    </HeaderTemplate>
                      <ItemTemplate>  
                           //******Some Items******
                      </ItemTemplate>
                    <FooterTemplate>   
                      <div style=" padding: 20px 35px;" id='ajax'>
                         <asp:TextBox ID="textbox" TextMode="MultiLine" Columns="50" Rows="10" runat="server" ></asp:TextBox>
                         <br />
                         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save" CommandName="cmd" CommandArgument="arg"/>                             
                      </div>  
                  </FooterTemplate>
                </asp:Repeater> 
 
    and add event in c# code like this -
    protected void rprSSNested_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            if (e.CommandName == "cmd")
            {
                string ss = ((TextBox)e.Item.FindControl("textbox")).Text;
                Response.Write(ss);
            }
        }
    }
