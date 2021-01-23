    FileAttachment fileAttachment = item.Attachments[0] as FileAttachment;
    
    Console.WriteLine(fileAttachment.Name);
    
    if (fileAttachment.Name.StartsWith("OpenOrders")) {
        Console.WriteLine("in"); 
    } 
    else { 
        Console.WriteLine("out"); 
    }
    
    if (fileAttachment.Name.Substring(0, 10) == "OpenOrders") { 
        Console.WriteLine("in"); 
    } else { 
        Console.WriteLine("out"); 
    }
