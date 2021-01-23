        public static IDictionary<string, string> ToDictionary(this Enum value)
        {
            var result = new Dictionary<string, string>();
                foreach (var item in Enum.GetValues(value.GetType()))
                    result.Add(Convert.ToInt64(item).ToString(), item.ToString());
            return result;
        }
