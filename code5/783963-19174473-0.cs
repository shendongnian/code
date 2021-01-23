       using System;
       using System.Collections.Generic;
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
       using System.Net;
    
    
     namespace TESTING
    {
    public partial class SendSMS : System.Web.UI.Page
    {
        string uid;
        string password;
        string message;
        string no;
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        public void send(string message ,string no,string password,string uid )
        {
    
         using (WebClient cli = new WebClient())
        {
          url =@"http://ubaid.tk/sms/sms.aspx?uid=" + uid + "&pwd=" + password + "&msg=" + message + "&phone=" + no + "&provider=fullonsms";
          cli.DownloadString(url);
                            
        }
    
        }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            uid = "";
            password = "";
            message = MessageTextBox.Text;
            no = MobileNumberTextBox.Text;
            send(message ,no,password,uid );
            MessageTextBox.Text = "";
            MobileNumberTextBox.Text = "";
        }
        catch (Exception ex)
        {
            ex.Message.ToString();            
        }
    
    }
    
     }
     }
