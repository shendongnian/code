        public static List<dynamic> ToDynamicList(this Hashtable ht)
        {
            var result = new List<dynamic>();
            foreach (DictionaryEntry de in ht)
            {
                result.Add(new { key = de.Key, value = de.Value });
            }
            return result;
        }
