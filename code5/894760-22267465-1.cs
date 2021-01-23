        /// <summary>
        /// Return the index row of a code if it exits, if not return -1
        /// </summary>
        /// <param name="code">the code you are looking for</param>
        /// <returns>its index</returns>
        private int ReturnIndexOfCodeIfAlreadyExists(string code)
        {
            var list = GetListOfCodes();
            if (list.Contains(code))
            {
                return list.IndexOf(code);
            }
            return -1;
        }
