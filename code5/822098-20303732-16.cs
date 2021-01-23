        private unsafe static void Fredou(string input, string replace, string[] replaceBy)
        {
            var output = new List<char[]>();
            var inputLength = input.Length;
            for (int i = 0; i < replaceBy.Length; ++i)
            {
                output.Add(new char[inputLength]);
            }
            Parallel.For(0, replaceBy.Length, l =>
            {
                var by = replaceBy[l];
                fixed (char* o = output[l], i = input)
                {
                    for (int j = 0; j < inputLength; ++j)
                    {
                        if ((j + 1) < inputLength && i[j + 1] == replace[1] && i[j] == replace[0] )
                        {
                            o[j] = by[0];
                            o[++j] = by[1];
                        }
                        else
                        {
                            o[j] = i[j];
                        }
                    }
                }
            });
        }
