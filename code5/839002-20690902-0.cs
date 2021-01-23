    if (pProp.Name == ("_ProjectName"))
    {
        var value = pProp.get_Value().ToString();
        using (StreamWriter writer = new StreamWriter(@"C:\Users\ngardner\Desktop\test.txt", true))
        {
            if (value.IndexOf("hayy", StringComparison.OrdinalIgnoreCase) > -1)
            {
                writer.Write("B");
            }
            else
            {
                if (value.IndexOf("incu", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    writer.Write("B");
                }
                else
                {
                    writer.Write("M");
                }
            }
        }
        // return here if needed
    }
