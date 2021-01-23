            private static Dictionary<int, ArrayList> J1_CarteDeck;
            private const string FILE_NAME = "Antize.data";
            public static void SaveDeck()
            {
                foreach (ArrayList child in J1_CarteDeck.Values)
                {
                    BinaryFormatter formatter   = new BinaryFormatter();
                    FileStream stream           = new FileStream(FILE_NAME, FileMode.Append, FileAccess.Write, FileShare.None);
    
                    formatter.Serialize(stream, child);
                    stream.Close();
                }
            }
    
            public static void LoadDeck()
            {
                int cptr            = 1;
    
                BinaryFormatter bf  = new BinaryFormatter();
                Stream stream       = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read);
    
                while (stream.Position < stream.Length)
                {
                    J1_CarteDeck[cptr] = (ArrayList)bf.Deserialize(stream);
                    cptr++;
                }
            }
