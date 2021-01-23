        private unsafe static void FredouImplementation(string input, int inputLength, string replace, string[] replaceBy)
        {
            var indexes = new List<int>();
            //my own string.indexof to save a few ms
            int len = inputLength;
            fixed (char* i = input, r = replace)
            {
                while (--len > -1)
                {
                    //i wish i knew how to do this in 1 compare :-)
                    if (i[len] == r[0] && i[len + 1] == r[1])
                    {
                        indexes.Add(len--);
                    }
                }
            }
            var idx = indexes.ToArray();
            len = indexes.Count;
            
            Parallel.For(0, replaceBy.Length, l =>
                Process(input, inputLength, replaceBy[l], idx, len)
            );
        }
        private unsafe static void Process(string input, int len, string replaceBy, int[] idx, int idxLen)
        {
            var output = new char[len];
            int l;
            fixed (char* o = output, i = input)
            {
                //direct copy, simulate string.copy
                for (l = 0; l < len; ++l)
                {
                    o[l] = i[l];
                }
                //replace, i also wish to know how to do this in 1 shot
                for (l = 0; l < idxLen; ++l)
                {
                    o[idx[l]] = replaceBy[0];
                    o[idx[l] + 1] = replaceBy[1];
                }
            }
            //Console.WriteLine(output);
        }
