    if (!mailItem.Categories.Contains(OutlookCategories.CategorieBijlage))
                                    {
                                        //if attachment is being saved add "attachment saved" category to mailitem
                                        mailItem.Categories = string.Format("{0}, {1}", OutlookCategories.CategorieBijlage, mailItem.Categories);
                                        //Opslaan van MailItem.
                                        mailItem.Save();
                                    }
