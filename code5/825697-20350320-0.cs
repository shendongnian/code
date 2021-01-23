                    var TemplatePath = userDetail.UserTypeTemplate.EmailTemplatePath;
                    var HeaderTemplateForPaidUser = ConfigurationManager.AppSettings["HeaderTemplateForPaidUser"];
                    var FooterTemplateForPaidUser = ConfigurationManager.AppSettings["FooterTemplateForPaidUser"];
                    toEmail = userDetail.Email;
                    fromEmail = ConfigurationManager.AppSettings["AdminMail"];
                    var sbMail = new StringBuilder();
                    using (var sReader = new StreamReader(HeaderTemplateForPaidUser))
                    {
                        sbMail.Append(sReader.ReadToEnd());
                        sbMail.Replace("{Name}", userDetail.Name);
                        sbMail.Replace("{CurrentDate}", currentDate.ToString("D"));
                    }
                    foreach (var tender in userTenders)
                    {
                        using (var sReader = new StreamReader(TemplatePath))
                        {
                            sbMail.Append(sReader.ReadToEnd());
                            sbMail.Replace("{TenderTitle}", tender.TenderTitle);
                            sbMail.Replace("{TenderID}", tender.TenderID.ToString("####"));
                            sbMail.Replace("{TenderType}", tender.TenderTypeName);
                            sbMail.Replace("{TenderValue}", tender.TenderValue.ToString("₹ 0,0", InCulture));
                            
                            sbMail.Append("<br />");
                        }
                    }
                    using (var sReader = new StreamReader(FooterTemplateForPaidUser))
                    {
                        sbMail.Append(sReader.ReadToEnd());
                    }
