    string userinput; // 3 or 4 char user input from TextBox
    string secondoctet = string.Empty;
    string thirdoctet = string.Empty;
    if (userinput.Length == 3)
    {
        secondoctet = userinput.Substring(0, 1);
        thirdoctet = userinput.Substring(1, 2);
    }
    if (userinput.Length == 4)
    {
        secondoctet = userinput.Substring(0, 2);
        thirdoctet = userinput.Substring(2, 2);
    }
    // using hardcoded IP format template inserting 2nd and 3rd octet into placeholders
    string targetip = string.Format("10.{0}.{1}.1", secondoctet, thirdoctet);
