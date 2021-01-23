    <form id="form1" runat="server">
       <div>
          <asp:HiddenField ID="Hidden1" runat="server"/>
      <div>    
     </form>
     protected void Page_Load(object sender, EventArgs e)
     {
            if ( !Page.IsPostBack)
            {
               Hidden1.Value = "Some Val";
            }
            else
            {
               string message =Hidden1.Value;
               // remaining code
            }
     }
