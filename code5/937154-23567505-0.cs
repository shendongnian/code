    <asp:UpdatePanel ID="UpDateGrid" runat="server">
       <ContentTemplate>
        <asp:Button ID="btnSaveInstitute" runat="server" 
         Text="Save"  OnClick="btnSave_Click" CausesValidation="false"></asp:Button>
        </ContentTemplate>
         <Triggers>
         <asp:AsyncPostBackTrigger ControlID="btnSaveInstitute" EventName="Click" />
         </Triggers>
         </asp:UpdatePanel>
