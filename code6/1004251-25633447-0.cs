    public void WriteFoodData(IEnumerable<Food> foodList, IEnumerable<Func<Food, object>> valueProviders)
    {
        using (StreamWriter sw = new StreamWriter("file.csv", false))
        {
            StringBuilder sb = new StringBuilder();
            foreach (Food f in foodList)
            {
                foreach (var provider in valueProviders)
                {
                    sb.Append(provider(f).ToString());
                }
                sw.WriteLIne(sb.ToString());
                sb.Clear();
            }
        }
    }
