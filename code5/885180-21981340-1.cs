      public static class BooleanExtensions
        {
            public static bool ToBool(this string value)
            {
                bool result = false;
                switch (value.ToLower().Trim())
                {
                    case "y":
                    case "yes":
                    case "1":
                        result = true;
                        break;
                    case "n":
                    case "no":
                    case "0":
                        result = false;
                        break;
                }
                return result;
            }
        }
