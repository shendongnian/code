    public static class MyIntConversion
    {
        public static bool MyTryParse(object parameter, out int value)
        {
            value = 0;
            try
            {
                value = Convert.ToInt32(parameter);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
