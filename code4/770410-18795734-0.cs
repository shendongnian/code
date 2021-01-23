    public static string CommentToUpper(string input)
    {
        int index = input.IndexOf("/*");
        if (index >= 0)
        {
            int endIndex = input.IndexOf("*/", index + 2);
            if (endIndex >= 0)
                return string.Format("{0}/*{1}*/{2}", 
                    input.Substring(0, index), 
                    input.Substring(index + 2, endIndex - index - 2).ToUpper(), 
                    input.Substring(endIndex + 2));
            else
                return string.Format("{0}/*{1}", 
                    input.Substring(0, index), 
                    input.Substring(index + 2).ToUpper());
        }
        return input;
    }
