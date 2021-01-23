    <script language="c#" runat="server">
    public void Page_Load(object sender, EventArgs e)
    {
       if(Request.QueryString["catl1"] == "ask_the_expert")
         ucTalkToExpert1.Visible = false;
       else
         ucTalkToExpert1.Visible = true;
    }
    </script>
