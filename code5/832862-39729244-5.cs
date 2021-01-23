    try
    {
     
     
    }
    catch(Exception ex)
    {
        //this will save the exception details and mark exception as low priority
        ex.Save();
    }
     
     
    try
    {
     
     
    }
    catch(Exception ex)
    {
        //this will save the exception details with  priority you define: High, Medium,Low
        ex.Save(ImpactLevel.Medium);
    }
     
    try
    {
     
     
    }
    catch(Exception ex)
    {
        //this will save the exception details with  priority you define: High, Medium,Low
        ex.Save(ImpactLevel.Medium, "You can enter an details you want here ");
    }
