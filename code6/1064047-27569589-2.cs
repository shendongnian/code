      <asp:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
          //put here gridview
        <ContentTemplate>
        <Triggers>
           <asp:AsyncPostBackTrigger ControlID="PageDropDownList" EventName="SelectedIndexChanged" />
        </Triggers>
      </asp:UpdatePanel>
    
