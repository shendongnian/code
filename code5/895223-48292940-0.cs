            public static void Remove(this List<string> words, string value, StringComparison compareType, bool removeAll = true)
        {
            if (removeAll)
                words.RemoveAll(x => x.Equals(value, compareType));
            else
                words.RemoveAt(words.FindIndex(x => x.Equals(value, compareType)));
        }
