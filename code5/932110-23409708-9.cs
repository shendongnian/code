        /// <summary>
        /// Converts a type's full name into a human readable string
        /// </summary>
        /// <param name="type">The type to convert</param>
        /// <returns>Type formatted as follows: Dictionary<List<String>,Queue<Int32>></returns>
        private static string ConvertTypeToReadableString(Type type)
        {
            string typeString = type.FullName;
            int endOfType = 0;
            if (typeString.Contains('`'))
            {
                //We have generic arguments
                endOfType = typeString.IndexOf('`');
                string mainType = typeString.Substring(0, endOfType);
                mainType = mainType.Split('.').Last(); // this equals "Dictionary"
                //Use this for namespace qualified names instead:
                //return typeString
                string result = mainType + "<";
                var genString = typeString.Substring(endOfType + 3);
                string[] generics = genString.Split('[', ']');
                generics = generics.Where(s => s != "" && s != "," && !s.StartsWith(",")).ToArray();
                //Get number of generic arguments to expect.
                int argCount = 0;
                int tempArgCount = 0;
                int i = 1;
                while (endOfType + 1 + i <= typeString.Length && Int32.TryParse(typeString.Substring(endOfType + 1, i), out tempArgCount))
                {
                    i++;
                    argCount = tempArgCount;
                }
                result += ParseGenerics(generics, argCount) + ">";
                return result;
            }
            else
            {
                //No generic arguments
                return typeString.Split('.').Last();
                //Use this for namespace qualified names instead:
                //return typeString;
            }
        }
        /// <summary>
        /// Convert generic arguments into simplified strings
        /// </summary>
        /// <param name="generics">List of strings, each containing one generic argument.</param>
        /// <returns>Single string of format Item1,Item2,Item3<Item4,Item5></returns>
        public static string ParseGenerics(string[] generics, int genericArgs)
        {
            string result = "";
            int index = 0;
            while(genericArgs > 0)
            {
                string generic = generics[index];
                if (generic.Contains('`'))
                {
                    //Another generic
                    int genericIndex = generic.IndexOf('`');
                    string mainType = generic.Substring(0, genericIndex).Split('.').Last();
                    //Use this if you want namespace-qualified names:
                    //string mainType = generic.Substring(0,genericIndex);
                    int i = 1;
                    //Get number of generic arguments to expect.
                    int argCount = 0;
                    int tempArgCount = 0;
                    while (genericIndex + 1 + i <= generic.Length && Int32.TryParse(generic.Substring(genericIndex + 1, i), out tempArgCount))
                    {
                        i++;
                        argCount = tempArgCount;
                    }
                    //Parse internal generics
                    result += mainType + "<" + ParseGenerics(generics.Skip(index + 1).ToArray(),argCount) + ">";
                    index += argCount;
                }
                else
                {
                    //Get type name
                    result += generic.Split(',').First().Split('.').Last();
                    //Use this if you want namespace-qualified names:
                    //result += generic.Split(',').First();
                }
                result += ",";
                genericArgs--;
                index++;
                
            }
            //remove trailing comma
            return result.Substring(0, result.Length - 1);
        }
