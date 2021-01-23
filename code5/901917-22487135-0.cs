        string str = "MyFavouriteChocIsDARKChocalate";
        System.Text.StringBuilder output = new System.Text.StringBuilder(str.Substring(0,1));
        for (int i = 1; i < str.Length; i++)
        {
            if (Char.IsUpper(str[i]) && (!char.IsUpper(str[i-1]) || (i+1 < str.Length && char.IsLower(str[i+1]))))
            {
                output.Append(" " + str[i]);
            }
            else
            {
                output.Append(str[i]);
            }
        }
        string result = output.ToString();
