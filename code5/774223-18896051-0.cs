     try
     {
       smtp1.Send(mm1);
       stream.Close();
     }
     catch (Exception exd)
     {
       Console.WriteLine(exd.ToString());
     }
    
