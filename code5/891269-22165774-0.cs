    string str = "BankMaster      AccountNo              decimal      To   varchar";
    StringBuilder temp = new StringBuilder();
    foreach(char ch in str)
    {
              if (ch == ' ' && temp[temp.Length-1] != ',')
                {
                    temp.Append(",");
                }
                else if (ch != ' ')
                {
                    temp.Append(ch.ToString());
                }
    }
      Console.WriteLine(temp);
