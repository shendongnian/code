    public int playerOneDart1Value;
    public int calculateDart1()
    {
        if (player == "t1" || player == "T1" || player == "3")
        {
            playerOneDart1Value = 3;
        }
        else if (string.IsNullOrEmpty(player))
        {
            playerOneDart1Value = 0;
        }
        else
        {
            MessageBox.Show("not valid input");
            //you can use something like a negative value to indicate invalid input
            playerOneDart1Value = -1;
        }
        return playerOneDart1Value;
    }
