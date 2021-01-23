    string erservice = "globalid=8679926300927194610,ou=services,globalid=00000000000000000000";
    int lastIndex = 0;
    int index;
    while ((index = erservice.IndexOf("globalid", lastIndex)) >= 0)
    {
        // Contains everything including and after each globalid=
        string part = erservice.Substring(index);
        lastIndex = index + 1;
        // do work
    }
    foreach (string section in erservice.Split(','))
    {
        // Gets each key/value pair
        string[] parts = section.Split('=');
        string key = parts[0];
        string value = parts[1];
        // do work
    }
