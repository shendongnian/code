    <asp:GridView ID="GridView3" runat="server"   
                  AllowPaging="True" DataKeyNames="DangerDownstream"
                  onpageindexchanging="GridView3_PageIndexChanging" 
                  backcolor="White" onrowdatabound="GridView3_RowDataBound"
                  PageSize="5" Width="100%" AutoGenerateColumns="False"
                  EnableModelValidation="True">
            <RowStyle CssClass="station_grid" />              
            <Columns>
              <asp:BoundField DataField="DangerDownstream" />
                 <asp:TemplateField HeaderText="Notification">
                    <ItemTemplate>
                      <asp:Image ID="Img" runat="server" Height="25px" Width="25px"/>
                      <asp:Label ID="Ln" runat="server" Text="Label"></asp:Label>
                     </ItemTemplate>
                   </asp:TemplateField>
             </Columns>
    </asp:GridView>
