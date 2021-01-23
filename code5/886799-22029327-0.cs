        // 3D version
        public Dictionary<int, Dictionary<int, Dictionary<int, double>>> GetNumCases3D(string varID1, string varID2, string varID3)
        {
            var cases3D = new Dictionary<int, Dictionary<int, Dictionary<int, double>>>();
            foreach (int value3 in ValuesFromVariable(varID3))
            {
                var cases2D = new Dictionary<int, Dictionary<int, double>>();
                cases3D[value3] = cases2D;
                foreach (int value2 in ValuesFromVariable(varID2))
                {
                    var cases1D = new Dictionary<int, double>();
                    cases2D[value2] = cases1D;
                    foreach (int value in ValuesFromVariable(varID1))
                    {
                        cases1D.Add(value, value + 0.1d);
                    }
                }
            }
            return cases3D;
        }
        private static int nIndex;
        private List<int> ValuesFromVariable(string s)
        {
            var result = new List<int>();
            for (int i = 0; i < s.Length; ++i)
                result.Add(++nIndex);
            return result;
        }
        // n-dimensional version
        public Dictionary<int, object> GetNumCasesNDim(params string[] input)
        {
            var result = new Dictionary<int, object>();
            int dimensions = input.Length;
            if (dimensions == 1)
            {
                foreach (int value in ValuesFromVariable(input[dimensions - 1]))
                {
                    result.Add(value, 0.01d);
                }
            }
            else
            {
                foreach (int value in ValuesFromVariable(input[dimensions - 1]))
                {
                    var nextParams = new List<string>(input);
                    int index = nextParams.Count - 1;
                    nextParams.RemoveAt(index);
                    result.Add(value, GetNumCasesNDim(nextParams.ToArray()));                    
                }
            }
            
            return result;
        }
        private void test()
        {
            nIndex = 0;
            var dim3 = GetNumCases3D("this", "is", "a");
            nIndex = 0;
            var testDimN = GetNumCasesNDim("this", "is", "a");
            nIndex = 0;
            var test2DimN = GetNumCasesNDim("this", "is", "a", "test");            
        }
