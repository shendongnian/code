    public async Task DoStuffForALongTime(CancellationToken ct)
    {
        while (someCondition)
        {
            if (ct.IsCancellationRequested)
            {
                return;
            }
    
            DoSomeStuff();
        }
    }
