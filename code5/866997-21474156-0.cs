    static void Main(string[] args)
    {
        DataTable dt = GetTable();
    
        DataRow[] dr = dt.Select("ID=2 and F_Name='raj'");
        if (dr !=null)
        {
            foreach (var item in dr)
            {
                item["F_name"] = "rajan";
            }
        }
    
    }
    
    static DataTable GetTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("F_name");
        dt.Columns.Add("L_name");
    
        dt.Rows.Add("1", "mit", "jain");          
        dt.Rows.Add("2", "raj", "patel");
        dt.Rows.Add("3", "anki", "patel");
        dt.Rows.Add("4", "alpa", "dumadiya");
    
        return dt;
    }
