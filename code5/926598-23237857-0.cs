            #region Attributes
            private static Timer m_TimerNextCheck;
            #endregion
    
            #region Méthodes publiques
            public static void StartCheck()
            {
                Thread licenceThread = new Thread(Checking);
                licenceThread.Start();
            }
            #endregion
    
            #region Méthodes privées
            private static void Checking()
            {
                //connect to the website
    
                try
                {
                    HttpWebResponse httpWebResponse = (HttpWebResponse) request.GetResponse();
    
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.Default);
    
                    string response = streamReader.ReadToEnd();
    
                    httpWebResponse.Close();
    
                    if (//Some code)
                    {
                        //Some code
                    }
                    else
                    {
    
                        if (m_TimerNextCheck == null)
                            m_TimerNextCheck = new Timer(TimerNextCheckFinished, null, 300000, Timeout.Infinite);
                        else
                            m_TimerNextCheck.Change(300000, Timeout.Infinite);
    
                    }
                }
                catch (WebException exception)
                {
                    //Some code
    
                    if (m_TimerNextCheck == null)
                        m_TimerNextCheck = new Timer(TimerNextCheckFinished, null, 60000, Timeout.Infinite);
                    else
                        m_TimerNextCheck.Change(60000, Timeout.Infinite);
                }
            }
    
            private static void TimerNextCheckFinished(object statusInfos)
            {
                Checking();
            }
            #endregion
