    string excelFileName = @"E:\OLA_MAIL_XL\GOPI_16122016.xls";
     DataTable dt = ds.Tables[0];
     string worksheetsName = "Report";
     ExcelPackage pack = new ExcelPackage();
     ExcelWorksheet wrkSht = pack.Workbook.Worksheets.Add(worksheetsName);
     wrkSht.Cells["A1"].LoadFromDataTable(dt, true);
     pack.SaveAs(new FileInfo(excelFileName));
      MailMessage msg = new MailMessage();
                    msg.To.Add(new MailAddress("gopi@kanike.com", "GOPIKRISHNA"));
                    
                    msg.From = new MailAddress("No-reply@domain.co.in", "Domain");
                    msg.Subject = "REPORTS";
                    string str = "Dear Team,<br/> Please find the Reports Details <br/><br/>";
                    Attachment attachment = new System.Net.Mail.Attachment(excelFileName);
                    msg.Attachments.Add(attachment);
                    msg.Body = str ;
                    msg.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient();
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("No-reply@domain.co.in", "");
                    client.Port = 25; // You can use Port 25 if 587 is blocked (mine is!)
                    client.Host = "domain@.com";
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Send(msg);
