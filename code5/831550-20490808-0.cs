    public struct MyData
    {
        public float? FloatData;
        public string StringData;
    }
    var serie_line = new
                     {
                         name = series_name,
                         data = new MyData()
                                {
                                    FloatData = theFloatData,
                                    StringData = theStringData,
                                }
                     };
