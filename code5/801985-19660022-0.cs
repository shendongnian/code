     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <Triggers>
           <asp:AsyncPostBackTrigger controlid="LnkAddTrack" eventname="Click" />         
         </Triggers>  
 
           <ContentTemplate>
             <div id="EventTrack" >
                <asp:Label ID="lblEventTracks" runat="server" Text="Event Tracks"></asp:Label>&nbsp;
                <asp:TextBox ID="txtEventTracks" CssClass="EventTextbox" runat="server"></asp:TextBox> 
                <asp:LinkButton ID="LnkAddTrack" ClientIDMode="Static"  runat="server" OnClick="LnkAddTrack_Click">Add Track</asp:LinkButton>
                </div>   
    <asp:GridView ID="dgTracks"  runat="server" >
                   <Columns> 
                       <asp:TemplateField HeaderText="TrackName">
                            <ItemTemplate>                       
                                <asp:Label ID="Control" runat="server" Text='<%#   Eval("TrackName") %>'></asp:Label>                        
                            </ItemTemplate>                                        
                        
                       </asp:TemplateField>
                   </Columns>
                </asp:GridView>
           </ContentTemplate>
      </asp:UpdatePanel>
