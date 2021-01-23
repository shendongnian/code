           int listid = int.Parse(ConfigurationManager.AppSettings["ListId"]);
            foreach (List list in account.lists().entries)
            {
                if (list.id == listid)
                {
                    foreach (Subscriber subscriber in list.subscribers().entries)
                    {
                        We Perform the check whether the email of the subscriber exist on the list or not & acc
                        if (subscriber.email == eid && subscriber.status != "unconfirmed")
                        {
                            try
                            {
                                if (subscriber.delete())
                                {
                                    //Response.Write("Subscriber Successfully Deleted");
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
        }
