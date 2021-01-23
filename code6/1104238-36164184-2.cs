    public static class HtmlHelperExtensions
    {
        public static HtmlString DisplayForPhone(this HtmlHelper helper, string phone)
        {
            if (phone == null)
            {
                return new HtmlString(string.Empty);
            }
            string formatted = phone;
            if (phone.Length == 10)
            {
                formatted = $"({phone.Substring(0,3)}) {phone.Substring(3,3)}-{phone.Substring(6,4)}";
            }
            else if (phone.Length == 7)
            {
                formatted = $"{phone.Substring(0,3)}-{phone.Substring(3,4)}";
            }
            string s = $"<a href='tel:{phone}'>{formatted}</a>";
            return new HtmlString(s);
        }
    }
