    public class modul_islemler 
    {
     public static  string modul_olustur(string data){
        string aranan = @"\[(.*?)\/\]";
        Regex objRegex = new Regex(aranan);
        MatchCollection objCol = objRegex.Matches(data); 
        foreach (Match item in objCol)
        {data = data.Replace(item.Groups[0].Value, modul_yaz(item.Groups[1].Value.ToString()));
        }
        return data;
    }
    public static  string modul_yaz(string sayfa)
    {       
        string[] ayir = sayfa.Split(' ');
        ArrayList myAL = new ArrayList();
        foreach (string a in ayir)
        {
            myAL.Add(a);
        }
        if (myAL.Count < 2) myAL.Add("");
        return LoadControl("~/plugins/" + myAL[0] + "/" + myAL[0] + ".ascx");
     }
     public static string LoadControl(string UserControlPath)
     {
       FormlessPage page = new FormlessPage();
        page.EnableViewState = false;
        // Create instance of the user control
        UserControl userControl = (UserControl)page.LoadControl(UserControlPath);
        page.Controls.Add(userControl);
        //Write the control Html to text writer
        StringWriter textWriter = new StringWriter();
    
        //execute page on server
        HttpContext.Current.Server.Execute(page, textWriter, false);
    
        // Clean up code and return html
        return textWriter.ToString();
       }
       public class FormlessPage : Page
    {
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
