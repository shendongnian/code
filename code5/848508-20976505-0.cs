    System.Collections.Generic.List<object> dataList = new System.Collections.Generic.List<object>();
    for (int k = 0; k < 4; k++)
            {
                List<HMData> Data_Content = new List<HMData>();
                for (int l = 0; l < 7; l++)
                {
    
                    Value_LfromList = LValues.ElementAt((k * 7) + l);
                    Value_IfromList = IValues.ElementAt((k * 7) + l);
                    Value_BfromList = BValues.ElementAt((k * 7) + l);
                    Data_Content.Add(new HMData { x = Value_LfromList, y = Value_IfromList, z = Value_BfromList });
                }
                dataList.Add(new {data = Data_Content});
            } 
      var chart = new
            {
                type = ChartType
            };
    var series = dataList;
    var obj = new { chart, series };
    string result = jSearializer.Serialize(obj);
