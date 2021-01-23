                int i = 0, current_line = 0;
    
                do
                {
                    if (i < side)
                    {
                        Console.Write("*");
                        i++;
                    }
                    else
                    {
                        Console.Write("\n");
    
                        i = 0;
                        current_line++;
                    }
                } while (current_line < side);
