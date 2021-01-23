    string Whatever = "foo";
    System.Threading.Timer timer = 
        new System.Threading.Timer(MyTimerCallback, whatever, 100, 100);
    void MyTimerCallback (object state)
    {
        string theData = (string)state;
        // at this point, theData is a reference to the "Whatever" string.
        // do tick processing
    }
