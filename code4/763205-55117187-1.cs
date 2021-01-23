    using System;
    using System.Net;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using System.IO;
    using System.Net.Mail;
    public string CreateByEmail_ID()
      {
            Microsoft.Office.Interop.Outlook._NameSpace ns = null;
            // Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
            Outlook._Application oApp = new Outlook.Application();
            Object selObject = oApp.ActiveExplorer().Selection[1];
            Microsoft.Office.Interop.Outlook.Application app = null;
            app = new Microsoft.Office.Interop.Outlook.Application();
            LogWriter.LogWrite1("Application :");
            ns = app.GetNamespace("MAPI");
            Outlook.MailItem mailItem = (selObject as Outlook.MailItem);
            createdbyEmail = mailItem.UserProperties.Session.CurrentUser.Address;
            if (app.Session.CurrentUser.AddressEntry.Type == "EX")
            {
                createdbyEmail = app.Session.CurrentUser.AddressEntry.GetExchangeUser().PrimarySmtpAddress;
            }
            else
            {
                createdbyEmail = app.Session.CurrentUser.AddressEntry.Address;
            }
            return createdbyEmail;
        }
