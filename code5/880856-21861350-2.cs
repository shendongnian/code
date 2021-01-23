    private void CalcMenu()
    {
        bool Done = false;
        while (!Done)
        {
            ShowMenu();
            if (MenuChoice == 0)
            {
                Done = true;
                //ReturnMainMenu();
            }
            else if (MenuChoice == 1)
            {
            }
            else if (MenuChoice == 2)
            {
            }
        }
        ReturnMainMenu(); //This should only happen when you exit the loop.
    }
