    var TemplatePath = userDetail.UserTypeTemplate.EmailTemplatePath;
    var headerTemplate = userDetail.UserTypeTemplate.EmailHeaderTemplatePath;
                    toEmail = userDetail.Email; 
                    fromEmail = ConfigurationManager.AppSettings["AdminMail"];
                    var sbMail = new StringBuilder();
                    using (var sReader = new StreamReader(headerTemplate))
                    {
                        sbMail.Append(sReader.ReadToEnd());
                        sbMail.Replace("{Name}", userDetail.Name);
                        sbMail.Replace("{CurrentDate}", currentDateTime.ToString("d"));
                    }
                    foreach (var tender in userTenders)
                    {
                        using (var sReader = new StreamReader(TemplatePath))
                        {
                            sbMail.Append(sReader.ReadToEnd());
                            sbMail.Replace("{TenderTitle}", tender.TenderTitle);
                            sbMail.Replace("{TenderID}", tender.TenderID.ToString());
                            sbMail.Replace("{TenderType}", tender.TenderTypeName);
                            sbMail.Replace("{TenderValue}", tender.TenderValue.ToString("₹ 0,0", InCulture));
                            sbMail.Replace("{TenderEMD}", tender.TenderEMD);
                            sbMail.Replace("{Location}", tender.Location);
                            sbMail.Replace("{OrgName}", tender.OrgName);
                            sbMail.Replace("{LastDateForSubmission}", tender.LastDateForSubmission.ToString("d"));
                            sbMail.Replace("{SubProductCatName}", tender.SubProductCatName);
                            sbMail.Append("<br />");
                        }
                    }
