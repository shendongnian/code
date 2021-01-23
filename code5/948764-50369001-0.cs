    public void ScheduleService()
        {
            try
            {
                dsData = new DataSet();
                _timeSchedular = new Timer(new TimerCallback(SchedularCallBack));
                dsData = objDataManipulation.GetInitialSMSConfig();
                if (dsData.Tables[0].Rows.Count > 0)
                {                    
                    DateTime scheduledTime = DateTime.MinValue;
                    scheduledTime = DateTime.Parse(dsData.Tables[0].Rows[0]["AUTOSMSTIME"].ToString());
                    if (string.Format("{0:dd/MM/YYYY HH:mm}", DateTime.Now) == string.Format("{0:dd/MM/YYYY HH:mm}", scheduledTime))
                    {
                        objDataManipulation.WriteToFile("Service Schedule Time Detected");
                        for (int iRow = 0; iRow < dsData.Tables[0].Rows.Count; iRow++)
                        {
                                if (dsData.Tables.Count > 1)
                                {
                                    if (dsData.Tables[1].Rows.Count > 0)
                                    {
                                        sendData(dsData);
                                    }
                                }
                                else
                                {
                                    objDataManipulation.WriteToFile("No SMS Content Data !");
                                }                        }
                    }
                    if (DateTime.Now > scheduledTime)
                    {
                        scheduledTime = scheduledTime.AddDays(1);
                    }                   
                    TimeSpan timeSpan = scheduledTime.Subtract(DateTime.Now);
                    string schedule = string.Format("{0} day(s) {1} hour(s) {2} minute(s) {3} seconds(s)", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                    
                    objDataManipulation.WriteToFile("TexRetail Service scheduled to run after: " + schedule + " {0}");
                    int dueTime = Convert.ToInt32(timeSpan.TotalMilliseconds);
                    //Change the Timer's Due Time.
                    _timeSchedular.Change(dueTime, Timeout.Infinite);                    
                }
            }
            catch (Exception ex)
            {                              
                objDataManipulation.WriteToFile("Service Error {0}" + ex.Message + ex.StackTrace + ex.Source);
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController(ServiceName))
                {
                    serviceController.Stop();
                }
            }
        }
