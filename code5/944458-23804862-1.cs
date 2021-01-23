        public static string[] RangeTest()
        {
            Boolean leadingZero = false;
            string num = "048030-48039"; //db.SelectNums(id);
            if (num.StartsWith("0"))
                leadingZero = true;
            int min = int.Parse(num.Split('-').Min());
            int count = int.Parse(num.Split('-').Max()) - min;
            if (leadingZero)
                return Enumerable.Range(min, count).Select(x => "0" + x.ToString()).ToArray();
            else
                return Enumerable.Range(min, count).Select(x => "" + x.ToString()).ToArray(); ;
        }
