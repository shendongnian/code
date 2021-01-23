        using System.IO;
        using System.Runtime.Serialization.Formatters.Binary;
    
        private static Dictionary<int, ArrayList> J1_CarteDeck;
    
        private static string PathDocuments = String.Format("{0}\\Antize Game\\", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        private const string FILE_NAME      = "Antize.data";
    
       public static bool SauvegarderDeck()
       {
           if (!(Directory.Exists(PathDocuments)))
               Directory.CreateDirectory(PathDocuments);
    
           if (File.Exists(PathDocuments + FILE_Deck))
               File.Delete(PathDocuments + FILE_Deck);
    
           foreach (ArrayList child in J1_CarteDeck.Values)
           {  
               if(child != null)
               { 
                    BinaryFormatter formatter   = new BinaryFormatter();
                    FileStream stream           = new FileStream(PathDocuments + FILE_Deck, FileMode.Append, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, child);
                    stream.Close();
                }
            }
    
            if (File.Exists(PathDocuments + FILE_Deck))
                return true;
            else
                return false;
        }
    
        public static bool ChargerDeck()
        {
            if (!(File.Exists(PathDocuments + FILE_Deck)))
                return false;
    
            int cptr = 1;
    
            J1_CarteDeck                = new Dictionary<int, ArrayList>();
    
            BinaryFormatter formatter   = new BinaryFormatter();
            Stream stream               = new FileStream(PathDocuments + FILE_Deck, FileMode.Open, FileAccess.Read, FileShare.None);
    
            while (stream.Position < stream.Length)
            {
                J1_CarteDeck[cptr] = (ArrayList)formatter.Deserialize(stream);
                cptr++;
            }
    
            stream.Close();
    
            return true;
        }
