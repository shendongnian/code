        public static IEnumerable<String> StreamSplit(this String thisStr, char splitChar)
        {
            if (thisStr == null)
                throw new ArgumentNullException();
            Int32 lastBegin = 0;
            for (Int32 i = 0; i < thisStr.Length; i++)
            { 
                if (thisStr[i] == splitChar)
                {
                     yield return thisStr.Substring(lastBegin, i - lastBegin + 1);
                     lastBegin = i;
                }
            }
            if (lastBegin != (thisStr.Length - 1))
                yield return thisStr.Substring(lastBegin); 
        }
    }
