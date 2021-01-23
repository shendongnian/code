    string result = String.Empty;
    string s = String.Format("{0:D4},{1:D4}", nx, ny);
    string[] values = s.Split(',');
    int counter = 0;
    foreach(string val in values)
    {
        if(counter > 0)
        {
            result += ",";
        }
        if(val.Length >= 2)
        {
            result += val.Substring(0,2);
        }
        else
        {
            result += val;
        }
        counter += 1;
    }
