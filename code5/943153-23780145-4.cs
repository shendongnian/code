    DateTime[] xValues = (from item in this.ItemsSource
                          let property = item.GetType().GetProperty(this.XValuesPath)
                          select (DateTime)property.GetValue(item)).ToArray();
    
    double[] yValues = (from item in this.ItemsSource
                        let property = item.GetType().GetProperty(this.YValuesPath)
                        select (double)property.GetValue(item)).ToArray();  
