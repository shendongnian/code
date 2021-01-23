                string theLine = "\n";
                string theEsc = ((char)27).ToString();
                while (!process.HasExited)
                    try {
                        //byte[] bytes = new byte[1];
                        ConsoleKeyInfo kinfo =  Console.ReadKey(true);
                        char theKey = kinfo.KeyChar;
                        theLine += theKey;
                                       switch (kinfo.Key)
            {
    
    case ConsoleKey.DownArrow:
                                process.StandardInput.Write(theEsc+"[B");
     break;
    case ConsoleKey.UpArrow:
                                process.StandardInput.Write(theEsc+"[A");
     break;
    default:
                                process.StandardInput.Write(theKey);
     break;
            }
                        process.StandardInput.Flush();
                        if (theKey.Equals('\n'))
                        {
                            Console.Write(theLine);
                            theLine = "\n";
    
                        }
    
                    }
