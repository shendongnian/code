    public sealed class NormalData
    {
        private readonly string _attributeName;
        private uint _count;
        private double _sum;
        private double _sumOfSquares;
        
        private NormalData(string attributeName)
        {
            _attributeName = attributeName;
        }
        
        public string AttributeName 
        {
            get { return _attributeName; }
        }
        
        public double Mean
        {
            get { return _count == 0 ? double.NaN : _sum / _count; }
        }
        
        public double StandardDeviation
        {
            get
            {
                if (_count == 0) return double.NaN;
    
                var diff = _sumOfSquares - (_sum * _sum / _count);
                return Math.Sqrt(diff / _count);
            }
        }
        
        public double EstimatedStandardDeviation
        {
            get
            {
                if (_count < 2) return double.NaN;
    
                var diff = _sumOfSquares - (_sum * _sum / _count);
                return Math.Sqrt(diff / (_count - 1));
            }
        }
        
        public void Add(double value)
        {
            _count = checked(_count + 1);
            _sum += value;
            _sumOfSquares += (value * value);
        }
        
        public static NormalData Create(string attributeName)
        {
            return new NormalData(attributeName, 0, 0, 0);
        }
    }
    
    public static IEnumerable<NormalData>  GetNormalDataByTableColumns(DataTable dt)
    {
        var normalDataList = dt.Columns.Cast<DataColumn>().Select(c => NormalData.Create(c.ColumnName)).ToList();
        
        foreach (DataRow row in dt.Rows)
        {
            foreach (NormalData item in normalDataList)
            {
                double value = row.Field<double>(item.AttributeName);
                item.Add(value);
            }
        }
        
        return normalDataList;
    }
