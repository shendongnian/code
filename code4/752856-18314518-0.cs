    public static string ShortDescription(string Description)
        {
            string result = Description;
            if (result.Length > 50)
            {
                result = result.Substring(0, 50);
                result += "....";
            }
            return result;
        }
