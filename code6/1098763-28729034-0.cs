    Test lastOn = null;
    int lastIndex = -1;
    for (int i = 0; i < tests.Length; i++)
    {
        switch (test[i].State)
        {
            case eState.blah:
               continue;
            case eState.On:
                if (lastOn == null)
                {
                    lastOn = test[i];
                    lastIndex = i;
                }
                break;
            case eState.Off:
                if (lastOn != null)
                {
                   if (test[i].Time - lastOn.Time < TimeSpan.FromMinutes(7))
                       Console.WriteLine(lastIndex + "," + i);
                   lastOn = null;
                }
            break;
        }       
    }
