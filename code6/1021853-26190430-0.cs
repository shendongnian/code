    using System.Text;
    public string CapitalizeFirstAndLast(string value)
        {
            string[] words = value.Split(' '); // break into individual words
            StringBuilder result = new StringBuilder();
            // Add the first word capitalized
            result.Append(words[0].ToUpper());
            // Add everything else
            for (int i = 1; i < words.Length - 1; i++)
                result.Append(words[i]);
            // Add the last word capitalized
            result.Append(words[words.Length - 1].ToUpper());
            return result.ToString();
        }
