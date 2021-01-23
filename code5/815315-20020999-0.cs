    var commands = Console.Readline(); 
    while(commands != "exit")
    {
    if (commands == "Read" || commands == "read")
            {
    
                fileread obj = new fileread();
    
                lcsString = obj.getlcs();
    
    
                commands = Console.ReadLine(); // If command = print I want it go to print              but it never goes . it loops out
            }
             else if (commands =="print")
            {
    
    
             }
    
    commands = Console.Readline();
    }
