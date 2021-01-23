        static bool CheckForSequence(List<int> input)
        {
            input.Sort();
            var result = true;
            for (int i = 0; i < input.Count - 1; i++)
            {
                result = input[i] == input[i + 1] - 1;
                if (!result)
                    break;
            }
            return result;
        }
