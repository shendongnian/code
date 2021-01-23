    SqlCommand cmd = new SqlCommand(str, con);
    command.Parameters.Add(new SqlParameter("@textInput", 0));
    
     for (int d = 0; d < YrStrList.Count; d++)
        {
     string text;
            text = YrStrList[d];
    command.Parameters["@textInput"].Value = text ;
    ...
    }
         
