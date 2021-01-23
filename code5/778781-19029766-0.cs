    <%@ Register TagPrefix="uc" TagName="uc1" 
                 Src="~/Controls/AddVisaUserControl.ascx" %>
    <uc:AddVisaControl id="uc1" runat="server" />
     protected void Page_Load(object sender, EventArgs e)
        {
            uc1.ButtonClickEvent += new yourusercontrol.ButtonClickEventHandler(Login1_ButtonClickEvent);
        }
    
        void uc1_ButtonClickEvent(string data)
        {
            lbldefaultaspx.Text = data.ToString();
        }
