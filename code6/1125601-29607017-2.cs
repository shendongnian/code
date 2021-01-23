    public static class ConvertUtil
    {
        public Int32 ToInt32(this String value)
        {
            return ToInt32(value, default(Int32));
        }
        public Int32 ToInt32(this String value, Int32 defaultValue)
        {
    #if NET4
            if (!String.IsNullOrWhiteSpace(value))
    #else
            if (!String.IsNullOrEmpty(value) && value.Trim().Length > 0)
    #endif
            {
                Int32 i;
                if (Int32.TryParse(value, out i))
                {
                    return i;
                }
            }
            return defaultValue;
        }
    }
    // explicit
    inRed = ConvertUtil.ToInt32(tbRed.Text, 0/* defaultValue*/);
    // As extension
    inRed = tbRed.Text.ToInt32(0/* defaultValue*/);
