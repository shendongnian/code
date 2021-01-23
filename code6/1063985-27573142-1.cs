    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendIf(
            this StringBuilder @this,
            bool condition,
            string str)
        {
            if (@this == null)
            {
                throw new ArgumentNullException("this");
            }
            if (condition)
            {
                @this.Append(str);
            }
            return @this;
        }
    }
