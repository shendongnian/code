    StreamReader SR = new StreamReader(myPath);
    String fill_in_var=SR.ReadLine();
    String line;
    while((line = SR.ReadLine()) != null)
    {
        Msg.Body+=line;
    }
    SR.Close();
    
    Msg.Body = Msg.Body.Replace(fill_in_var, "Test String");
