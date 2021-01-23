    public static class Extensions
    {
        public static string GetFullName(this Enum myEnum)
        {
          return string.Format("{0}.{1}", myEnum.GetType().Name, myEnum.ToString());
        }
    }
