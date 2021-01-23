    List<int> inputs = new List<int>();
    foreach(string o in inputText.Split(' '));//space character
    {
        bool correct = false;
        //add some controls for the control if the input is correct integer
        ...
        if(correct)
            inputs.Add(Convert.ToInt32(o));
    }
