        #region Attributs
        private Thread m_ConnectionThread;
        private Timer m_TimerConnectionThread;
        #endregion
        #region Méthodes publiques
        public void Launch()
        {
            m_ConnectionThread = new Thread(Connect);
            m_ConnectionThread.Start();
        }
        public void GetNextMeal()
        {
            //Some code
            if (//Some code)
            {
                //Some code
                if (m_TimerConnectionThread == null)
                    m_TimerConnectionThread = new Timer(TimerConnectionThreadFinished, null, 
                        (int)TimeSpan.FromHours(difference.Hour).TotalMilliseconds + 
                        (int)TimeSpan.FromMinutes(difference.Minute).TotalMilliseconds, Timeout.Infinite);
                else
                    m_TimerConnectionThread.Change((int)TimeSpan.FromHours(difference.Hour).TotalMilliseconds + 
                        (int)TimeSpan.FromMinutes(difference.Minute).TotalMilliseconds, Timeout.Infinite);
            }
            else
            {
                //Some code
            }
        }
        public void TryReconnect(int minute)
        {
            //Some code
            if (m_TimerConnectionThread == null)
                m_TimerConnectionThread = new Timer(TimerConnectionThreadFinished, null, (int)TimeSpan.FromMinutes(minute).TotalMilliseconds,
                    Timeout.Infinite);
            else
                m_TimerConnectionThread.Change((int)TimeSpan.FromMinutes(minute).TotalMilliseconds, Timeout.Infinite);
            //Some code
        }
        //Some code
        #endregion
        #region Méthodes privées
        private void Connect()
        {
            if (m_TimerConnectionThread != null)
                m_TimerConnectionThread.Change(Timeout.Infinite, Timeout.Infinite);
            //Some code
        }
        //Some code
        private void TimerConnectionThreadFinished(object stateInfo)
        {
            Connect();
        }
        #endregion
