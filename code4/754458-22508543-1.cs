        MailMessage mail = new MailMessage();
        //set the addresses
        mail.From = new MailAddress("userid@gmail.com");
        mail.To.Add("userid@gmail.com");
        //set the content
        mail.Subject = "Sucessfully Sent the HTML and Content of mail";
        //first we create the Plain Text part
        string plainText = "Non-HTML Plain Text Message for Non-HTML enable mode";
        AlternateView plainView = AlternateView.CreateAlternateViewFromString(plainText, null, "text/plain");
        XmlTextReader reader = new XmlTextReader(@"E:\HTMLPage.htm");
        string[] address = new string[30];
        string finalHtml = "";
        var i = -1;
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element)
            { // The node is an element.
                if (reader.AttributeCount <= 1)
                {
                    if (reader.Name == "img")
                    {
                        finalHtml += "<" + reader.Name;
                        while (reader.MoveToNextAttribute())
                        {
                            if (reader.Name == "src")
                            {
                                i++;
                                address[i] = reader.Value;
                                address[i] = address[i].Remove(0, 8);
                                finalHtml += " " + reader.Name + "=" + "cid:chartlogo" + i.ToString();
                            }
                            else
                            {
                                finalHtml += " " + reader.Name + "='" + reader.Value + "'";
                            }
                        }
                        finalHtml += ">";
                    }
                    else
                    {
                        finalHtml += "<" + reader.Name;
                        while (reader.MoveToNextAttribute())
                        {
                            finalHtml += " " + reader.Name + "='" + reader.Value + "'";
                        }
                        finalHtml += ">";
                    }
                }
            }
            else if (reader.NodeType == XmlNodeType.Text)
            { //Display the text in each element.
                finalHtml += reader.Value;
            }
            else if (reader.NodeType == XmlNodeType.EndElement)
            {
                //Display the end of the element.
                finalHtml += "</" + reader.Name;
                finalHtml += ">";
            }
        }
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(finalHtml, null, "text/html");
        LinkedResource[] logo = new LinkedResource[i + 1];
        for (int j = 0; j <= i; j++)
        {
            logo[j] = new LinkedResource(address[j]);
            logo[j].ContentId = "chartlogo" + j;
            htmlView.LinkedResources.Add(logo[j]);
        }
        mail.AlternateViews.Add(plainView);
        mail.AlternateViews.Add(htmlView);
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new NetworkCredential(
            "userid@gmail.com", "Password");
        smtp.EnableSsl = true;
        Console.WriteLine();
        smtp.Send(mail);
    }
