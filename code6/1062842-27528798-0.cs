    if (Form2.dosya_adi != null)
    {
        string cfile = Form2.chosenfile;
        path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\DATA\\" + cfile+ ".txt";
    
    }
    else 
    {
        path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)+"\\DATA";
    }
