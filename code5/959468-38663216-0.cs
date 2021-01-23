    public static bool UpdateLeadTime(int ltId, int ltDays)
        {
            try
            {
                using (var db = new LeadTimeContext())
                {
                    var result = db.LeadTimes.SingleOrDefault(l => l.LeadTimeId == ltId);
                    if (result != null)
                    {
                        result.LeadTimeDays = ltDays;
                        db.SaveChanges();
                        logger.Info("Updated ltId: {0} with ltDays: {1}.", ltId, ltDays);
                    }
                    else
                    {
                        LeadTime leadtime = new LeadTime();
                        leadtime.LeadTimeId = ltId;
                        leadtime.LeadTimeDays = ltDays;
                        try
                        {
                            db.LeadTimes.Add(leadtime);
                            db.SaveChanges();
                            logger.Info("Inserted ltId: {0} with ltDays: {1}.", ltId, ltDays);
                        }
                        catch (Exception ex)
                        {
                            logger.Warn("Error captured in UpdateLeadTime({0},{1}) was caught: {2}.", ltId, ltDays, ex.Message);
                            logger.Warn("Inner exception message: {0}", ex.InnerException.InnerException.Message);
                            if (ex.InnerException.InnerException.Message.Contains("IDENTITY_INSERT"))
                            {
                                logger.Warn("Attempting workaround...");
                                try
                                {
                                    db.Database.Connection.Open();  // required to update database without db.SaveChanges()
                                    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT[dbo].[LeadTime] ON");
                                    db.Database.ExecuteSqlCommand(
                                        String.Format("INSERT INTO[dbo].[LeadTime]([LeadTimeId],[LeadTimeDays]) VALUES({0},{1})", ltId, ltDays)
                                        );
                                    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT[dbo].[LeadTime] OFF");
                                    logger.Info("Inserted ltId: {0} with ltDays: {1}.", ltId, ltDays);
                                    // No need to save changes, the database has been updated.
                                    //db.SaveChanges(); <-- causes error
                                    
                                }
                                catch (Exception ex1)
                                {
                                    logger.Warn("Error captured in UpdateLeadTime({0},{1}) was caught: {2}.", ltId, ltDays, ex1.Message);
                                    logger.Warn("Inner exception message: {0}", ex1.InnerException.InnerException.Message);
                                }
                                finally
                                {
                                    //Verification
                                    if (ReadLeadTime(ltId) == ltDays)
                                    {
                                        logger.Info("Insertion verified. Workaround succeeded.");
                                    }
                                    else
                                    {
                                        logger.Info("Error!: Insert not verified. Workaround failed.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Warn("Error in UpdateLeadTime({0},{1}) was caught: {2}.", ltId.ToString(), ltDays.ToString(), ex.Message);
                logger.Warn("Inner exception message: {0}", ex.InnerException.InnerException.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
