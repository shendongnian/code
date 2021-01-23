    while (read.Read())
    {
        string mail = read["Mail"].ToString();
        try
        {
            message.To.Clear();
            message.To.Add(mail);
       
            //email    
            smtp.Send(message);
        }
        catch
        {
            MessageBox.Show("Text");
        } 
    } 
