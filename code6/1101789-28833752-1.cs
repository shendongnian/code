    static List<double> list = new List<double>();
    static public void OpenColumn(IEnumerable<string> strs, int highNum)//, int highNum2)
        {
            var columnQueryOpen = from line in strs
                                  let elements = line.Split(',')
                                  select Convert.ToDouble(elements[highNum]);
            list.AddRange(columnQueryOpen.ToList());
        }
