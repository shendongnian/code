    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string fileName = context.Request.QueryString["filename"];
            context.Response.ContentType = "image/jpeg";
            context.Response.TransmitFile(@"D:\Users\Images\Pictures\" + fileName);
        }
    
        public bool IsReusable
        {
            get { return false; }
        }
    }
    
    ASPX
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <asp:Image runat="server" 
                ImageUrl='<%# "~/ImageHandler.ashx?filename=" + Eval("Value") %>' />
        </ItemTemplate>
    </asp:Repeater>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] filePaths = Directory.GetFiles(@"D:\Users\Images\Pictures");
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new ListItem(fileName, fileName)); 
            }
            Repeater1.DataSource = files;
            Repeater1.DataBind();
        }
    }
