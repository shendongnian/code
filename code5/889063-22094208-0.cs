    public static String getDateString()
            {
                DateTime time = DateTime.Now;
                String sqlFormattedDate = time.ToString("yyyy-MM-dd HH:mm:ss");
    
                return sqlFormattedDate;
            }
