        private void Test()
        {
            permutation(new string[] { "AB", "CD", "E" }, 0, "");
        }
        private void permutation(string[] options, int srcPos, string result)
        {
            if (result.Length == options.Length)
                Console.WriteLine(result);
            else
            {
                foreach (char opt in options[srcPos])
                {
                    permutation(options, srcPos + 1, result + opt);
                }
            }
        }
