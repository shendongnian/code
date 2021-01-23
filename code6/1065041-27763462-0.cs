     new Thread(() =>
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        for (int j = 0; j < 50000; j++)
                        {
    
                            myGraphicsLayer.Graphics[j].Symbol = mySimpleLineSymbol;
                        }
                    });
    
                }
    ).Start();
    
    
                new Thread(() =>
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        for (int k = 50000; k < 100000; k++)
                        {
                            myGraphicsLayer.Graphics[k].Symbol = mySimpleLineSymbol;
                        }
                    });
    
                }
    ).Start();
    
    
                new Thread(() =>
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        for (int l = 100000; l < 150000; l++)
                        {
                            myGraphicsLayer.Graphics[l].Symbol = mySimpleLineSymbol;
                        }
                    });
    
                }
    ).Start();
    
    
                new Thread(() =>
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        for (int m = 150000; m < 200000; m++)
                        {
                            myGraphicsLayer.Graphics[m].Symbol = mySimpleLineSymbol;
                        }
                    });
    
                }
    ).Start();
