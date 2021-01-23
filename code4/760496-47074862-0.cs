    void UpdateListOutput()
        {
                Dispatcher.BeginInvoke(new Action(() => {
                    while (true)
                    {
                        if (!string.IsNullOrEmpty(engineOutput))
                        {
                            OutputBox.Items.Add(engineOutput);
                        }
                    }                
                
                }));
               
            
        }
