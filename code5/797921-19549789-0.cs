    public Button[] ButtonCreator(byte numOfBtnsNeeded)
    {
        Button[] mybtns = new Button[numOfBtnsNeeded];
        for (int i = 0; i < mybtns.Length; i++)
        {
            mybtns[i] = new Button();
            mybtns[i].Name = (i + 1).ToString();
        }
        return mybtns;
    }
