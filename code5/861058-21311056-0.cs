    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Google.GData.Client;
    using Google.Contacts;
    using Google.GData.Extensions;
     public partial class _Default : System.Web.UI.Page 
    {
       protected void Page_Load(object sender, EventArgs e)
      {
       
      }
     protected void Button1_Click(object sender, EventArgs e)
     {
        // Define string of list
        List<string> lstContacts = new List<string>();
        // Below requestsetting class take 3 parameters applicationname, gmail username, gmail password. 
        // Provide appropriate Gmail account details
        RequestSettings rsLoginInfo = new RequestSettings("", "MailId", "Password");
        rsLoginInfo.AutoPaging = true;
        ContactsRequest cRequest = new ContactsRequest(rsLoginInfo);
        // fetch contacts list
        Feed<Contact> feedContacts = cRequest.GetContacts();
        // looping the feedcontact entries
        foreach (Contact gmailAddresses in feedContacts.Entries)
        {
            // Looping to read email addresses
            foreach (EMail emailId in gmailAddresses.Emails)
            {
                lstContacts.Add(emailId.Address);
            }
        }
        // finally binding the list to gridview defined in above step
        
        GridView1.DataSource = lstContacts;
        GridView1.DataBind();
        
      }
 
     }
