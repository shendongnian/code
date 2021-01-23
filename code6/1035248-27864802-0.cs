        public static bool Exists(this IWebElement element)
        {
            try
            {
                var text = element.Text;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
