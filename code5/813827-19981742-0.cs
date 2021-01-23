            var nestedDictionary = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
            var foundCounter = 0;
            foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, string>>> midLevel in nestedDictionary)
            {
                var key = midLevel.Key;
                if (key.Equals("WHATAMILOOKINGFOR"))
                {
                    foundCounter++;
                }
                foreach (KeyValuePair<string, Dictionary<string, string>> lowerLevel in midLevel.Value)
                {
                    if (key.Equals("WHATAMILOOKINGFOR"))
                    {
                        foundCounter++;
                    }
                    if(lowerLevel.Value.ContainsKey("WHATAMILOOKINGFOR"))
                    {
                        foundCounter++;
                    }
                }
            }
