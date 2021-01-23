     class Flight
        {
            
            public string Consonants(string direction)
            {
                string[] words = direction.Split('-');
                // check if the separator is missing
                if (words.Length!=2) return string.Empty; //missing separator error
      
                return string.Format("{0}-{1}", Replacer(words[0]),  Replacer(words[1]));
            }
            private string Replacer(string arg)
            { 
                string abr= arg.ToUpper().Replace("A", string.Empty).Replace("E", string.Empty).Replace("I", string.Empty).Replace("O", string.Empty).Replace("U", string.Empty);
                if (abr.Length < 2)
                    throw new Exception(string.Format("processing error in Replacer input {0} outpur {1}", arg, abr)); // example if you pass: UAE
                    
                return string.Format("{0}{1}", abr[0], abr[abr.Length - 1] );
            }
    
        }
