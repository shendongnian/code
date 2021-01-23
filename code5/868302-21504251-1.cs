                   {
                        string line = sr.ReadToEnd();
                        var words = line.Split(new Char[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);
                        
                        return words;
                    }
