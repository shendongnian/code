    List<int> integer = new List<int>();
    string number="";
    foreach(char o in yourString)
    {
        try
        {
            Convert.ToInt32(Convert.ToString(o));//try if o == an integer
            number+=o;
        }
        catch
        {
            if(number!="")
            {
                integer.Add(Convert.ToInt32(number));
                number="";
            }
        }
    }
