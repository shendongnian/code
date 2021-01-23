    public static class X
    {
        public static void Process(this object[] myList)
        {
            foreach (dynamic item in myList)
            {
                item.Id += 1;
            }
        }
    }
