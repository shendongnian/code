    using System;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal1.Mode = LiteralMode.Encode;
            Literal2.Mode = LiteralMode.PassThrough;
            Literal3.Mode = LiteralMode.Transform;
    
            Literal1.Text = @"<font size=4 color=red>Literal1 with Encode property example</font><script>alert(""Literal1 with the Encode property"");</script></br></br>";
    
            Literal2.Text = @"<font size=4 color=green>Literal2 with PassThrough property example</font><script>alert(""Literal2 with the PassThrough property"");</script></br></br>";
    
            Literal3.Text = @"<font size=4 color=blue>Literal3 with Encode Transform example</font><script>alert(""Literal3 with the Transform property"");</script></br></br>";
        }
    }
