        public static char returnSecondDuplicate(char[] arr)
        {
            if (arr.Length == 0)
                throw new ArgumentNullException("Empty Array passed");
            var dictionary = new Dictionary<char, int>();
            char firstDuplicate = '\0';
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (!dictionary.ContainsKey(arr[i]))
                {
                    dictionary.Add(arr[i], 1);
                }
                else if (firstDuplicate == '\0')
                {
                    firstDuplicate = arr[i];
                }
                else if(arr[i] != firstDuplicate)
                {
                        return arr[i];
                }
                
            }
            return '\0'; //not found
        }
