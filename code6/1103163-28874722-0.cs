    public static string sample(object arr)
    {
        
        object[] res= arr as object[];
        if (res != null)
        {
            string[] sRes = res.OfType<string>().ToArray();
        }
        return "";
    }
