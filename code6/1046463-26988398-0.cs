    public static class Extensions{
        public static string Sum30(this int[] array)
        {
            var res = (from a in array
                        from b in array
                        where a + b == 30
                        select new
                        {
                            element = a.ToString() + "," + b.ToString()
                        }).FirstOrDefault(t => t != null);
    
            return res == null ? string.Empty : res.element;
        }
    }
    then use it like this
            var arr = new int[] { 86, 12, 39, 14, 90, 0, 16, 19,18, 17 };
            var returnvalue = arr.Sum30();
