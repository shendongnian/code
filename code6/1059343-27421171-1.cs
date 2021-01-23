        private List<List<string>> SplitList(List<string> input, int size = 5)
        {
            var result = new List<List<string>>();
            int counter = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var partResult = new List<string>();
                while (true)
                {
                    partResult.Add(input[i]);
                    if ((i+1) % size == 0)
                    {
                        break;
                    }
                    i++;
                }
                result.Add(partResult);
            }
            return result;
        }
