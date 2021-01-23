    Please use the following code :
    
       
    
        static int i = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            Label1.Text = "(20)";
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
    
            i--;
            Label1.Text =i.ToString();
          
            if (i == 0)
            {
                Session["Profession"] = "Visiteur";
                Response.Redirect("Acceuil.aspx");
            }
        }
    
    
        your HTML code should be like :
        
        <form id="form1" runat="server">
            <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                 
                </asp:ScriptManager>
            
              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                       
                       
                  
                     <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="1000">
                       </asp:Timer>
                    </ContentTemplate>
                
                </asp:UpdatePanel>
                   
            </div>
            </form>
