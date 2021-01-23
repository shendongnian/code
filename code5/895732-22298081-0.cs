    string[] lines = System.IO.File.ReadAllLines("C:\\Users\\Public\\Usernames.txt")
    int line_number= 0;
    for(;line_number< lines.Length; line_number++)
    {
        if(lines[line_number] == registeredUser)
            break;
    }
    //Your line number is now contained in line_number
