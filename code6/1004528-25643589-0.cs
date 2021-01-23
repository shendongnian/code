    using System.IO; //you have to add this
    protected string OutputHtml;
    protected void Page_Load(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(Server.MapPath("~/TextFiles/template.txt"));
        String line = sr.ReadToEnd();
        OutputHtml = line;
    }
