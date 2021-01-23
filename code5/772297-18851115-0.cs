    public class trading_book_product_IRS        
    {
        public DataTable dt_IRS { get; set; }
        public string account_deal_position_id { get; set; }
        public DateTime? schedule_start_date { get; set; }
        public DateTime? schedule_end_date { get; set; }
        public string repricing_type { get; set; }
        public string coupon_type { get; set; }
        public string reference_curve { get; set; }
        public string reference_curve_point { get; set; }
        public decimal interest_rate { get; set; }
        public decimal interest_rate_spread { get; set; }        
    }
    public static DataTable CreateDataTable(Type type)
    {
        var dataTable = new DataTable();
        foreach (PropertyInfo info in type.GetProperties())
        {
            if(info.PropertyType == typeof(DataTable)) continue;
            
            DataColumn column;
            
            var type = Nullable.GetUnderlyingType(info.PropertyType);
            
            if(type != null)
            {
                column = new DataColumn(info.Name, type)
            }
            else
            {
                column = new DataColumn(info.Name, info.PropertyType);
            }
            
            dataTable.Columns.Add(column);
        }
        
        return dataTable;
    }
