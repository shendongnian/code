    DataTable dt = new DataTable();
    dt.Columns.Add("PaymentMonth", typeof(System.DateTime));
    dt.Columns.Add("Amount", typeof(int));
    
    dt.Rows.Add(new DateTime(2014, 1, 1), 100);
    dt.Rows.Add(new DateTime(2014, 2, 1), 200);
    dt.Rows.Add(new DateTime(2014, 3, 1), 200);
    dt.Rows.Add(new DateTime(2015, 1, 1), 300);
    dt.Rows.Add(new DateTime(2015, 2, 1), 300);
    dt.Rows.Add(new DateTime(2016, 1, 1), 200);
    
    var sumResult = from amt in dt.AsEnumerable()
                    group amt by amt.Field<System.DateTime>("PaymentMonth").Year into agg
                    select new { Year=agg.Key,SumAmount=agg.Sum(r=>r.Field<int>("Amount")) };
    
    DataTable dtAgg = new DataTable();
    dtAgg.Columns.Add("Year",typeof(int));
    dtAgg.Columns.Add("Amount", typeof(int));
    
    foreach(var item in sumResult)
    {
       dtAgg.Rows.Add(item.Year, item.SumAmount);
    }
