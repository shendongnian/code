    if (pProp.Name == ("_ProjectName"))
    {
       var value = pProp.get_Value().ToString();
        
       if (value.IndexOf("hayy", StringComparison.OrdinalIgnoreCase) > 0)
       {
           using (StreamWriter writer = new StreamWriter(@"C:\Users\ngardner\Desktop\test.txt", true))
           {
                    writer.Write("B");
                    return;
           }
        }
        else
        {
            if (value.IndexOf("incu", StringComparison.OrdinalIgnoreCase) > 0)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\ngardner\Desktop\test.txt", true))
                {
                    writer.Write("B");
                    return;
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\ngardner\Desktop\test.txt", true))
                {
                    writer.Write("M");
                }
            }
        }
    }
