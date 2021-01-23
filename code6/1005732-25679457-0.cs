            string[] dates = new [] { "2014-01-01", "01-01-2014"};
            foreach (string d in dates)
            {
                DateTime parsed;
                if (DateTime.TryParseExact(d, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
                    Console.WriteLine("yyyy-MM-dd: {0}", parsed);
                else if (DateTime.TryParseExact(d, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
                    Console.WriteLine("dd-MM-yyyy: {0}", parsed);
            }
