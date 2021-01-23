    <script runat="server">
      void Page_Load(Object sender, EventArgs e) {
        if (Page.IsPostBack) {
          string s = username.Text;
          Response.Write(s);
        }
      }
    </script>
