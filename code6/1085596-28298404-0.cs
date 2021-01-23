     object missing = System.Reflection.Missing.Value;
            try
            {
                OutLook.MAPIFolder fldContacts = null;;
                OutLook._Application outlookObj = new OutLook.Application();
                string folderName = "Default";
                
                fldContacts = (OutLook.MAPIFolder)outlookObj.Session.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderContacts);
                //LOOPIN G THROUGH CONTACTS IN THAT FOLDER.
                foreach (Microsoft.Office.Interop.Outlook._ContactItem contactItem in fldContacts.Items)
                {
                   
                        StringBuilder strb = new StringBuilder();
                        strb.AppendLine((contactItem.FirstName == null) ? string.Empty : contactItem.FirstName);
                        strb.AppendLine((contactItem.LastName == null) ? string.Empty : contactItem.LastName);
                        strb.AppendLine(contactItem.Email1Address);
                        strb.AppendLine(contactItem.Business2TelephoneNumber);
                        strb.AppendLine(contactItem.BusinessAddress);
                        //write to text file
                        StreamWriter sw = null;
                        sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                        sw.WriteLine(DateTime.Now.ToString() + ": " + strb.ToString());
                        sw.Flush();
                        sw.Close();
                   
                }
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
