        public IEnumerable<ResultsOfCallMyMethod> PrepareTestCases(string param)
        {
            foreach (string entry in entries)
            {
                yield return CallMyMethod(param);
            }
        }
