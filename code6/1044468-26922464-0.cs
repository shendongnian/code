    static Int32[] ProcessDelete( Player[] players, Int32 RemoveAt) //Change Int32 to In32[]
        {
            Int32[] newIndicesArray = new Int32[players.Length - 1];
            int i = 0;
            int j = 0;
            while (i < players.Length)
            {
                if (i != RemoveAt)
                {
                    newIndicesArray[j] = players[i];
                    j++;
                }
                i++;
            }
            return newIndicesArray;
        }
           
