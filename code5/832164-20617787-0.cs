        private bool ContainsFlag(string contents)
        {
            int indexOfMethodDec = contents.IndexOf(_method);
            int indexOfNextPublicMethod = contents.IndexOf("public", indexOfMethodDec);
            if (indexOfNextPublicMethod == -1)
                indexOfNextPublicMethod = int.MaxValue;
            int indexOfNextPrivateMethod = contents.IndexOf("private", indexOfMethodDec);
            if (indexOfNextPrivateMethod == -1)
                indexOfNextPrivateMethod = int.MaxValue;
            int indexOfNextProtectedMethod = contents.IndexOf("protected", indexOfMethodDec);
            if (indexOfNextProtectedMethod == -1)
                indexOfNextProtectedMethod = int.MaxValue;
            int[] indeces = new int[3]{indexOfNextPrivateMethod,
                                       indexOfNextProtectedMethod,
                                       indexOfNextPublicMethod};
            int closestToMethod = indeces.Min();
            if (closestToMethod.Equals(Int32.MaxValue))
                return false; //This should probably do something different.. This condition is true if the method you're reading is the last method in the class, basically
            List<int> openBraces = new List<int>();
            List<int> closeBraces = new List<int>();
            string pattern = "{";
            foreach (Match m in Regex.Matches(contents, pattern))
                openBraces.Add(m.Index);
            for (int i = 0; i < openBraces.Count; i++)
            {
                if (i < indexOfMethodDec)
                    openBraces.Remove(i);
                else
                    break;
            }
            pattern = "}";
            foreach (Match m in Regex.Matches(contents, pattern))
                closeBraces.Add(m.Index);
            for (int i = 0; i < closeBraces.Count; i++)
            {
                if (i < indexOfMethodDec || i > closestToMethod)
                    openBraces.Remove(i);
            }
            if (closestToMethod - indexOfMethodDec < 0)
                return false;
            string methodBody = contents.Substring(indexOfMethodDec, closestToMethod - indexOfMethodDec);
            if (methodBody.Contains(_flag))
                return true;
            return false;
        }
