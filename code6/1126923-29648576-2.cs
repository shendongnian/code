    string Post_Code_PAR = "";
    String[] PostCode_Array = Post_Code_PAR.Split(',');
    var zipCodeList = query.Where(x => CustomFilter(x.Post_Code, PostCode_Array)).ToList();
            
    private static bool CustomFilter(string code, string[] foundZipCodes)
    {
        return foundZipCodes.Any(x =>
        {
            x = x.Trim();
            var text = x.Replace("*", "");
            if (x.EndsWith("*"))
                return code.StartsWith(text);
            if (x.StartsWith("*"))
                return code.EndsWith(text);
            if (x.Contains("*"))
                return false;
            return true;
        });
    }
