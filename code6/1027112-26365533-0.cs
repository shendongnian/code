        private bool SameSeparatorValid(char c)
        {
            string testValue = String.Format("1{0}852{0}520", c);
            double expected = 1852.52;
            var nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = c.ToString(),
                NumberGroupSeparator = c.ToString()
            };
            try
            {
                double actual = Double.Parse(testValue, nfi);
                return (expected == actual);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void IterateCultures()
        {
            string msgFormat = "Found {0} cultures (of {1})" 
                + " where NumberGroupSeparator == NumberDecimalSeparator";
            var allCis = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var cis = allCis.Where(
                ci => ci.NumberFormat.NumberGroupSeparator 
                    == ci.NumberFormat.NumberDecimalSeparator);
            Console.WriteLine(msgFormat, cis.Count(), allCis.Count());
            var allAscii = Enumerable.Range(0, 127);
            var asciis = allAscii
                .Where(c => SameSeparatorValid((char)c));
            msgFormat = "Found {0} ASII characters (of {1})" 
                + " where NumberGroupSeparator == NumberDecimalSeparator is valid";
            Console.WriteLine(msgFormat, asciis.Count(), allAscii.Count());
       }
