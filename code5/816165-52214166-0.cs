       public int AddColFromLetter(string s)
        {
            int column = 0;
            int iter = 1;
            foreach (char c in s)
            {
                int index = char.ToUpper(c) - 64;//Ahmed KRAIEM
                //int index = (int)c % 32;//Valdimir
                if(iter == 1)
                    column += index;
                if(iter > 1)
                    column += 25+ index;
                iter++;
            }
            return column;
        }
