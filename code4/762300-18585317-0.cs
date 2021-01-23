    Dictionary<Type,bool> colorEaches = new Dictionary<Type,bool>();
    colorEaches[typeof(DevExpress.XtraCharts.BarDrawOptions)] = true;
    colorEaches[typeof(DevExpress.XtraCharts.StackedBarSeriesView)] = true;
    //.....
    bool value;
    if(colorEaches.TryGetValue(sser.View.GetType(),out value)){
       sser.View.GetType().GetProperty("ColorEach").SetValue(sser.View, value);
    }else {
      //your own code
    }
