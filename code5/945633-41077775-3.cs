    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
             <b>Image Preview: </b><br />
             <asp:Image ID="img" runat="server" CssClass="profileImage" />
             <br /> 
             <br />
             <asp:Button ID="btnRotate" runat="server" Text="Rotate Image" ClientIDMode="Static" OnClick="btnRotate_Click" />
             <br />
             <br />
          </ContentTemplate>
          <Triggers>
               <asp:PostBackTrigger ControlID="btnRotate" />
          </Triggers>
    </asp:UpdatePanel>
