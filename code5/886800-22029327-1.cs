        public Dictionary<int, object> GetNumCasesNDim(params string[] input)
        {
            var result = new Dictionary<int, object>();
            int dimensions = input.Length;
            if (dimensions == 1)
            {
                foreach (int value in ValuesFromVariable(input[dimensions - 1]))
                {
                    result.Add(value, 0.01d /*dummy double*/);
                }
            }
            else
            {
                foreach (int value in ValuesFromVariable(input[dimensions - 1]))
                {
                    var nextParams = new List<string>(input);
                    nextParams.RemoveAt(nextParams.Count - 1);
                    result.Add(value, GetNumCasesNDim(nextParams.ToArray()));                    
                }
            }
            return result;
        }
