    public int FindPattern(byte[] Body, byte[] Pattern, bool[] Wild, int start = 0)
        {
            int foundIndex = -1;
            bool match = false;
    
            if (Body.Length > 0 
                && Pattern.Length > 0 
                && start <= Body.Length - Pattern.Length && Pattern.Length <= Body.Length)
                for (int index = start; index <= Body.Length - Pattern.Length; index += 4)
                    if (Wild[0] || (Body[index] == Pattern[0]))
                    {
                        match = true;
                        for (int index2 = 1; index2 <= Pattern.Length - 1; index2++)
                        {
                            if (!Wild[index2] &&
                              (Body[index + index2] != Pattern[index2]))
                            {
                                match = false;
                                break;
                            }
    
                        }
    
                        if (match)
                        {
                            foundIndex = index;
                            break;
                        }
                    }
    
            return foundIndex;
        }
