    string input = "12345678"; //could be any length
    int position = 3; //could be any other number
    StringBuilder sb = new StringBuilder();
    
    for (int i = 0; i < input.Length; i++)
    {
        if (i % position == 0){
            sb.Append('-');
    	}
        sb.Append(input[i]);
    }
    string formattedString = sb.ToString();
