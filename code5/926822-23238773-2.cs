    public class Indicator
    {
        List<MyData> _dataList = new List<MyData>();
    
        public bool IsContained(MyData data)
        {
    
            return _dataList.Exists(x => x.Key == data.Key 
                                      && x.Key1 == data.Key1
                                      && x.Key2 == data.Key2);
        }
    
        public void Add(MyData data)
        {
            _dataList.Add(data);
        }
    }
