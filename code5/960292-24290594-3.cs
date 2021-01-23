    public static DataTable AddColumn<T>(this DataTable dt, string name)
    {
         dt.Columns.Add(name, typeof(T));
         return dt;
    }
