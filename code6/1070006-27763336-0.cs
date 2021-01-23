    public static List<string[]> Partition(this string[] source, Int32 size)
        {
            var output = new List<string[]>();
            for (int i = 0; i < Math.Ceiling(source.Count() / (Double)size); i++)
                output.Add(source.Skip(size * i).Take(size).ToArray());
            return output;
        }
