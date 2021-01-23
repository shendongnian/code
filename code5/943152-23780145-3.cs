    var xValues = (from item in this.ItemsSource
                   let property = item.GetType().GetProperty(this.XValuesPath)
                   select property.GetValue(item)).ToArray();
    
    var yValues = (from item in this.ItemsSource
                   let property = item.GetType().GetProperty(this.YValuesPath)
                   select property.GetValue(item)).ToArray();
