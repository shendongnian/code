    string newline = "How to insert newline character after ninth word of(here) the string such that the remaining string is in next line";
    StringBuilder sb = new StringBuilder(newline);
    int spaces = 0;
    int length = sb.Length;
    for (int i = 0; i < length; i++)
    {
        if (sb[i] == ' ')
        {
            spaces++;
        }
        if (spaces == 9)
        {
            sb.Insert(i, Environment.NewLine);
            break;
            //spaces = 0; //if you want to insert new line after each 9 words
        }
    }
    string str = sb.ToString();
