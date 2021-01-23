        public bool TryParse(string source, out Point point)
        {
            try
            {
                point = Point.Parse(source);
            }
            catch (FormatException ex)
            {
                point = default(Point);
                return false;
            }
            return true;
        }
