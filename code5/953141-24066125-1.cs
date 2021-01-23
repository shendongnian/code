      <asp:TextBox ID="tb_FirstName" runat="server"></asp:TextBox>
  
       Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
          If IsPostBack = False Then
              tb_FirstName.Attributes.Add("onChange", "saveAsingleTextbox(this);") 
          End If
              
       End Sub
