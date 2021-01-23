    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    namespace Sample
    {
        public partial class frmSample : Form
        {
            Outlook.NameSpace outlookNameSpace;
            Outlook.MAPIFolder inbox;
            Outlook.Items items;
            public frmSample()
            {
                InitializeComponent();
            }
    
            private void frmSample_Load(object sender, EventArgs e)
            {
                Outlook.Application app = new Outlook.Application();
                outlookNameSpace = app.GetNamespace("MAPI");
                inbox = outlookNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                items = inbox.Items;
                items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
            }
            void items_ItemAdd(object Item)
            {
                Outlook.MailItem mail = (Outlook.MailItem)Item;
                if (Item != null)
                {
                    string tempvariable = mail.To;
                    tempvariable = mail.Subject;
                    tempvariable = mail.Body;
                    tempvariable = mail.SenderEmailAddress;
                    tempvariable = mail.SenderName.ToString();                        
                 }
               }
            }
        }
    }
