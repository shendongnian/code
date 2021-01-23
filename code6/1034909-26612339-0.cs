    <script runat="server">
      void Page_Load(Object sender, EventArgs e) {
        if (Page.IsPostback) {
          string s = username.Text;
          Response.Write(s);
        }
      }
    </script>
