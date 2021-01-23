        /// <summary>
        /// Creates and connects the hub connection and hub proxy. 
        /// </summary>
        private async void ConnectWithRetryAsync()
        {
            Connection = new HubConnection(Properties.Settings.Default.ServerBaseUrl);
            Connection.Closed += Connection_Closed;
            Connection.Error += Connection_Error;
            HubProxy = Connection.CreateHubProxy("signalcalendar");
            //Handle incoming event from server: use Invoke to write to log from SignalR's thread
            HubProxy.On<CalendarUpdateRequest>("UpdateCalendarEvent", (calendarUpdateRequest) =>
                this.Invoke((Action)(() =>
                {
                    try
                    {
                        if (calendarUpdateRequest == null) return;
                        // Reject my own calendar's changes
                        if (calendarUpdateRequest.UserInfo.UserId == Program.UserInfo.UserId) return;
                        //Notify all opened Form about Calendar changes
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            var openForm = Application.OpenForms[i];
                            try
                            {
                                var currentFormType = openForm.GetType();
                                if (currentFormType == typeof(CommonForm))
                                {
                                    if ((openForm as CommonForm).AppWindowType == AppWindowTypes.FactTruckForm ||
                                        (openForm as CommonForm).AppWindowType == AppWindowTypes.PlanTruckForm ||
                                        (openForm as CommonForm).AppWindowType == AppWindowTypes.FactExcForm ||
                                        (openForm as CommonForm).AppWindowType == AppWindowTypes.PlanExcForm)
                                    {
                                        (openForm as CommonForm).CalendarHasBeenChanged(calendarUpdateRequest);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                logger.Error(ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
                ))
            );
            #region  Connect to the Server
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException ex)
            {
                var errorMessage = "There is no connection with Server. Check your netwrok and Server App state";
                logger.Error(errorMessage);
                logger.Error(ex);
                MetroMessageBox.Show(this, errorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            #endregion
            //Activate UI          
            logger.Info("COnnection has been established OK");
        }
