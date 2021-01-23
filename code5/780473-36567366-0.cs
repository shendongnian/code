                string strUrl = SPContext.Current.Site.Url + "/" + subSite;
                using (SPSite Site = new SPSite(strUrl))
                {
                    using (SPWeb Web = Site.OpenWeb())
                    {
                        SPList List = Web.Lists[listName];
                        SPListItem item = List.GetItemById(ID);
                        foreach (String attachmentname in item.Attachments)
                        {
                            AnnouncementsCommon objAnnouncementsCommon = new AnnouncementsCommon();
                            String attachmentAbsoluteURL = item.Attachments.UrlPrefix + attachmentname;
                            objAnnouncementsCommon.AttachmentName = attachmentname;
                            objAnnouncementsCommon.AttachmentURL = attachmentAbsoluteURL;
                            lstAnnouncementsCommon.Add(objAnnouncementsCommon);
                        }
                    }
                }
            }
            catch (Exception Exc)
            {
                Microsoft.Office.Server.Diagnostics.PortalLog.LogString("SSC DAL Exception Occurred: {0} || {1}", Exc.Message, Exc.StackTrace);
            }
            return lstAnnouncementsCommon;
        }
