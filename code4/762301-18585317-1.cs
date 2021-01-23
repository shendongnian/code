    //Use this Dictionary to pair the view types and their corresponding ColorEach to set accordingly
    Dictionary<Type,bool> colorEaches = new Dictionary<Type,bool>();
    colorEaches[typeof(DevExpress.XtraCharts.BarDrawOptions)] = true;
    colorEaches[typeof(DevExpress.XtraCharts.StackedBarSeriesView)] = true;
    //.....
    bool value;
    Type viewType = sser.View.GetType();
    if(colorEaches.TryGetValue(viewType,out value)){
       //Suppose your `ColorEach` should be present in all the types added to the Dictionary
       viewType.GetProperty("ColorEach").SetValue(sser.View, value);
    }else {
      //your own code
    }
