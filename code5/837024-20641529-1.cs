        public static IEnumerable<NormalData>  GetNormalDataByTableColumns(DataTable dt)
        {
            dt.Columns.Select(c => {
              var values = dt.Values(c);
              return new NormalData(values.Average(), values.StDev, c.ColoumnName); //Added constructor too as it makes sense to me, but can use named args if not 
            });
        }
