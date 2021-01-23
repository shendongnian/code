    public partial class Form : System.Web.UI.Page
    {       
        public int Num
        {
             get {
                    if(ViewState["num"] != null)
                       return int.Parse(ViewState["num"]); 
                    else
                       return 0;  
                  }
             set { ViewState["num"] = value; }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {    
            Label_PageNumber.Text = "Page0" + Num.ToString();    
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            Num++;    
            Label_PageNumber.Text = "Page0" + Num.ToString();    
        }
    }
