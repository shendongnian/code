    <%@ Import Namespace="CMS.DocumentEngine" %>
    <script runat="server">
      protected void Page_Load(object sender, EventArgs e)
      {
        yourPlaceHolderControl.Visible = !String.IsNullOrEmpty(DocumentContext.CurrentDocument.GetStringValue("Intro", String.Empty));
      }
    </script>
