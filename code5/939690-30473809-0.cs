    SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite spSite = new SPSite(SiteURL))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        headers = new StringDictionary();
                        headers.Add("to", To);
                        headers.Add("from", From);
                        headers.Add("cc", CC);
                        headers.Add("bcc", BCC);
                        if (Priority.Equals("High"))
                        {
                            headers.Add("X-Priority", "1 (Highest)");
                            headers.Add("X-MSMail-Priority", "High");
                            headers.Add("Importance", "High");
                        }
                        headers.Add("subject", Subject);
                        headers.Add("content-type", "text/html");
                        Status = SPUtility.SendEmail(spWeb, headers, Body);
                    }
                }
            });
