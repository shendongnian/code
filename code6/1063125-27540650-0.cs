    public static class DisplayExtension 
    {
        public static string DisplayResult(this string input)
        {
            var resultString = "";
            foreach (char ch in input.ToCharArray())
            {
                resultString += "S3 : " + ch.ToString() + "\n";
            }
            return resultString;
        }
    }
