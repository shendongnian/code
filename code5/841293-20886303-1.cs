    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using CommunicatorAPI;
    namespace MARSWebCommunicator
    {
        public partial class _Default : Page
        {
            CommunicatorAPI.Messenger communicator = null;
            List<CustomContacts> lstContactDetails;
            protected void Page_Load(object sender, EventArgs e)
            {
                lstContactDetails = new List<CustomContacts>();
                communicator = new CommunicatorAPI.Messenger();
                string mymailid = "Chandan.kumarpanda@effem.com";
                var contact = GetContact(mymailid);
                int s = (int) contact.Status;
                lblStatus.Text = GetStatus(s);
                if (!Page.IsPostBack)
                {
                    drpEmails.Items.Add(mymailid);
                    lblName.Text = contact.SigninName.ToString();
                    HiddenField1.Value = contact.SigninName.ToString();
                    lstContactDetails = GetAllEmailsWithFiendlyName();
                    foreach (CustomContacts aContact in lstContactDetails)
                    {
                        drpEmails.Items.Add(aContact.ContactEmailId);
                    }
                }
            }
      
            protected void drpEmails_SelectedIndexChanged(object sender, EventArgs e)
            {
                string currentmailid = drpEmails.SelectedItem.Text;
                var contact = GetContact(currentmailid);
                lblName.Text = contact.FriendlyName.ToString();
                int s = (int)contact.Status;
                lblStatus.Text = GetStatus(s);
                if (HiddenField1.Value != "")
                {
                    HiddenField1.Value = "";
                    HiddenField1.Value = contact.SigninName.ToString();
                }
            }
            protected string GetStatus(int s)
            {
                string status = string.Empty;
                string src = string.Empty;
                int tempstatusno = s;
                switch (s)
                {
                    case 0 :
                        status = "UNKNOWN";
                        src = "presence_images/presence_16-unknown.bmp";
                        break;
                    case 1:
                        status = "OFFLINE";
                        src = "presence_images/presence_16-off.bmp";
                        break;
                    case 2:
                        status = "ONLINE";
                        src = "presence_images/presence_16-online.bmp";
                        break;
                    case 6:
                        status = "INVISIBLE";
                        src = "presence_images/presence_16-unknown.bmp";
                        break;
                    case 10:
                        status = "BUSY";
                        src = "presence_images/presence_16-busy.bmp";
                        break;
                    case 14:
                        status = "BE_RIGHT_BACK";
                        src = "presence_images/presence_16-idle-busy.bmp";
                        break;
                    case 18:
                        status = "IDLE";
                        src = "presence_images/presence_16-idle-online.bmp";
                        break;
                    case 34:
                        status = "AWAY";
                        src = "presence_images/presence_16-away.bmp";
                        break;
                    case 50:
                        status = "ON_THE_PHONE";
                        break;
                    case 66:
                        status = "OUT_TO_LUNCH";
                        break;
                    case 82:
                        status = "IN_A_MEETING";
                        break;
                    case 98:
                        status = "OUT_OF_OFFICE";
                        break;
                    case 114:
                        status = "DO_NOT_DISTURB";
                        src = "presence_images/presence_16-dnd.bmp";
                        break;
                    case 130:
                        status = "IN_A_CONFERENCE";
                        break;
                    case 146:
                        status = "ALLOW_URGENT_INTERRUPTIONS";
                        break;
                    case 162:
                        status = "MAY_BE_AVAILABLE";
                        break;
                    case 178:
                        status = "CUSTOM";
                        break;
                    default:
                        status = "OFFLINE";
                        src = "presence_images/presence_16-unknown.bmp";
                        Image1.ImageUrl = src;
                        break;
                }
                Image1.ImageUrl = src;
                return status;
            }
            public IMessengerContact GetContact(string signinName)
            {
                return communicator.GetContact(signinName, communicator.MyServiceId) as IMessengerContact;
            }
            public List<CustomContacts> GetAllEmailsWithFiendlyName()
            {
                List<CustomContacts> lstContacts = new List<CustomContacts>();
                IMessengerContacts messengerContacts = (IMessengerContacts)communicator.MyContacts;
                foreach (IMessengerContact acontact in messengerContacts)
                {
                    CustomContacts aContact = new CustomContacts();
                    aContact.ContactName = acontact.FriendlyName.ToString();
                    aContact.ContactEmailId = acontact.SigninName.ToString();
                    lstContacts.Add(aContact);
                }
                return lstContacts;
            }
        }
        public class CustomContacts
        {
            public string ContactEmailId { get; set; }
            public string ContactName { get; set; }
            public string ContactStatus { get; set; }
        }
    }
