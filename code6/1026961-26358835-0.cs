    if (GUI.Button(new Rect(100, 275, 300, 25), "Add All numbers between 1 and 999999999"))
            {
                stopWatch.Start();
                AddAllNumbersMax();
    
            }
    
        GUI.TextArea(new Rect(275, 100, 300, 300), _messageLog);
    }
    
    void AddAllNumbersMax()
    {
        int max = 999999999;
        double result = 0;
        for (int i = 0; i<=max; i++) 
        {
            result += i;
    
        }
        _messageLog += result + "\n";
        stopWatch.Stop ();
        _messageLog += stopWatch.Elapsed;
    
    }
