        void spinner_DoWork(object o, DoWorkEventArgs args)
            {        
    this.Dispatcher.BeginInvoke(new Action(() => {
    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Idle; //tried without and with
                float angle = 0;
                bool stopSpinning = m_currentData != null && m_currentData.isLoaded == true;
                while (!stopSpinning )
                {
                    //spin something
                    angle++;
                    if (angle > 360.0f)
                    {
                        angle = 0.0f;                        
                    }
        
                    _spinthatspinner.ReportProgress((int)angle);
        
                    if (m_currentData != null && m_currentData.isLoaded == true)
                    {
                        stopSpinning = true;
                    }
                } 
    }));   
                
        
            }
