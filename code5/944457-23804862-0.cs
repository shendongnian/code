        public static string[] RangeTest()
        { 
            string num = "48030-48039"; //db.SelectNums(id);
            int min = int.Parse(num.Split('-').Min());
            int count = int.Parse(num.Split('-').Max()) - min;
            return Enumerable.Range(min, count).Select(x => x.ToString()).ToArray(); ;
        }
