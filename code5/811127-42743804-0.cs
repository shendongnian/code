    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.Net;
    using System.Configuration;
    using System.IO;
    using System.Net.Mail;
    using System.Runtime.InteropServices;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using Office = Microsoft.Office.Core;
	public enum BodyType
	{
		PlainText,
		RTF,
		HTML
	}
        //....
		public static bool sendEmailViaOutlook(string sFromAddress, string sToAddress, string sCc, string sSubject, string sBody, BodyType bodyType, List<string> arrAttachments = null, string sBcc = null)
		{
			//Send email via Office Outlook 2010
			//'sFromAddress' = email address sending from (ex: "me@somewhere.com") -- this account must exist in Outlook. Only one email address is allowed!
			//'sToAddress' = email address sending to. Can be multiple. In that case separate with semicolons or commas. (ex: "recipient@gmail.com", or "recipient1@gmail.com; recipient2@gmail.com")
			//'sCc' = email address sending to as Carbon Copy option. Can be multiple. In that case separate with semicolons or commas. (ex: "recipient@gmail.com", or "recipient1@gmail.com; recipient2@gmail.com")
			//'sSubject' = email subject as plain text
			//'sBody' = email body. Type of data depends on 'bodyType'
			//'bodyType' = type of text in 'sBody': plain text, HTML or RTF
			//'arrAttachments' = if not null, must be a list of absolute file paths to attach to the email
			//'sBcc' = single email address to use as a Blind Carbon Copy, or null not to use
			//RETURN:
			//		= true if success
			bool bRes = false;
			try
			{
				//Get Outlook COM objects
				Outlook.Application app = new Outlook.Application();
				Outlook.MailItem newMail = (Outlook.MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);
				//Parse 'sToAddress'
				if (!string.IsNullOrWhiteSpace(sToAddress))
				{
					string[] arrAddTos = sToAddress.Split(new char[] { ';', ',' });
					foreach (string strAddr in arrAddTos)
					{
						if (!string.IsNullOrWhiteSpace(strAddr) &&
							strAddr.IndexOf('@') != -1)
						{
							newMail.Recipients.Add(strAddr.Trim());
						}
						else
							throw new Exception("Bad to-address: " + sToAddress);
					}
				}
				else
					throw new Exception("Must specify to-address");
				//Parse 'sCc'
				if (!string.IsNullOrWhiteSpace(sCc))
				{
					string[] arrAddTos = sCc.Split(new char[] { ';', ',' });
					foreach (string strAddr in arrAddTos)
					{
						if (!string.IsNullOrWhiteSpace(strAddr) &&
							strAddr.IndexOf('@') != -1)
						{
							newMail.Recipients.Add(strAddr.Trim());
						}
						else
							throw new Exception("Bad CC-address: " + sCc);
					}
				}
				//Is BCC empty?
				if (!string.IsNullOrWhiteSpace(sBcc))
				{
					newMail.BCC = sBcc.Trim();
				}
				//Resolve all recepients
				if (!newMail.Recipients.ResolveAll())
				{
					throw new Exception("Failed to resolve all recipients: " + sToAddress + ";" + sCc);
				}
				
				//Set type of message
				switch (bodyType)
				{
					case BodyType.HTML:
						newMail.HTMLBody = sBody;
						break;
					case BodyType.RTF:
						newMail.RTFBody = sBody;
						break;
					case BodyType.PlainText:
						newMail.Body = sBody;
						break;
					default:
						throw new Exception("Bad email body type: " + bodyType);
				}
				if (arrAttachments != null)
				{
					//Add attachments
					foreach (string strPath in arrAttachments)
					{
						if (File.Exists(strPath))
						{
							newMail.Attachments.Add(strPath);
						}
						else
							throw new Exception("Attachment file is not found: \"" + strPath + "\"");
					}
				}
				//Add subject
				if(!string.IsNullOrWhiteSpace(sSubject))
					newMail.Subject = sSubject;
				Outlook.Accounts accounts = app.Session.Accounts;
				Outlook.Account acc = null;
				//Look for our account in the Outlook
				foreach (Outlook.Account account in accounts)
				{
					if (account.SmtpAddress.Equals(sFromAddress, StringComparison.CurrentCultureIgnoreCase))
					{
						//Use it
						acc = account;
						break;
					}
				}
				//Did we get the account
				if (acc != null)
				{
					//Use this account to send the e-mail. 
					newMail.SendUsingAccount = acc;
					//And send it
					((Outlook._MailItem)newMail).Send();
					//Done
					bRes = true;
				}
				else
				{
					throw new Exception("Account does not exist in Outlook: " + sFromAddress);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR: Failed to send mail: " + ex.Message);
			}
			return bRes;
		}
