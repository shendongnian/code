    while (someCondition)
    {
        System.Threading.Thread.Sleep(500);
        Application.Current.Dispatcher.Invoke(MyMethod);
    }
    private void MyMethod()
    {
        if (someOtherCondition)
        {
            // Do stuff...
        }
        else
        {
            if (anotherCondition)
            {
                break;
            }
            // Do something else...
        }
    }
