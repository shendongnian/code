    private void start_Click(object sender, RoutedEventArgs e)
    {
        Task.Run(()=>{
        foreach (TestObject tObj in tObjList)
        {
            bool testResult = tObj.makeTest();
            Dispatcher.Invoke(()=>{
            foreach (TestShower ts in m_TSList)
            {
                if (tObj == ts.gettObj())
                {
                    if (testResult == true)
                        ts.setLightOn();
                    else
                        ts.setLightOff();
                    ts.UpdateLayout();
                    break;
                }
            }});
           }
        }
      });
    }    
