    string userInput = "hi";
    string myOutput = String.Empty;
    while (yourReader.Read())
    {
        if (yourReader["InputColumn"].ToString().Equals(userInput))
        {
            myOutput = yourReader["ResponseColumn"].ToString();
            break;
        }
    }
    yourReader.Close();
