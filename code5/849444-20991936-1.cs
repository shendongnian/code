    <%@ Register Src="~/WebUserControls/TestUC.ascx" TagName="WebUserControlTest"
    TagPrefix="uctest" %>
     <asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
       <asp:Label ID="lbl1" runat="server" >Label</asp:Label>
       <uctest:WebUserControlTest ID="ucTest" runat="server"></uctest:WebUserControlTest>
     </asp:Content>
