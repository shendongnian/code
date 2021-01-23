    private static string THECORRECTPIN = "1234";
    private string _PinEntered{get;set;}
    public void KeyPressed(string number)
    {
        _PinEntered += number;//here's the important bit
        if(_PinEntered == THECORRECTPIN)
        {
            Unlock();
        }
    
    }
