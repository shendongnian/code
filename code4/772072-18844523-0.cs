        public static int[] NumberList(string source, string filter)
        {
            var split = Regex.Split(source, "(\\d+,\\s*\\w)");
            var list = (from s in split where s.EndsWith(filter)
                           select int.Parse( s.Split(',')[0])).ToArray();
            return list;
        }
