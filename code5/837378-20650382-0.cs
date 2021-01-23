private static string ConvertNullToEmptyString(DataTable element)
    {
        if (string.IsNullOrEmpty(element.Rows[0]["USER_COMMENT"]))
        {
            return "NO DATA";
        }
        else
        {
            return element.Rows[0]["USER_COMMENT"].ToString();
        }
    }
