      try{
                                  PublicationReporting();
                            }
    
                              catch (Exception ex)
                            {
    
                                pgError.Text = "Publication Exception Message: " + ex.Message;
    
                            }
    
                              finally
                              {
                                  csoW_connection.Close();
                              }
