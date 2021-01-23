    while (someCondition)
    {
        System.Threading.Thread.Sleep(500);
    
        Application.Current.Dispatcher.Invoke(new Action(() =>
        {
            if (someOtherCondition)
            {
                // Do stuff...
            }
            else
            {
                if (anotherCondition)
                {
                    //break;
                    someCondition = false;
                    return;
                }
    
                // Do something else...
            }
        }));
        if (!someCondition)
            break;
    }
