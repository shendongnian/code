    private bool canEnter=false;
    private void TestFunc(int a)
    {
        switch(a)
        {
             case(0):
             {
                 Console.WriteLine("Zero");
                 canExit=true;
                 break;
             }
        }
    
        TestFunc(b);
        if(!canEnter)
        {
            HelloFunc(0);
            ThisFunc();
        }
    }
