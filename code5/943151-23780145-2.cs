    DateTime dt = new DateTime();
    DateTime[] xValues = (from item in this.ItemsSource
                          let property = item.GetType().GetProperty(this.XValuesPath)
                          let value = property.GetValue(item)
                          let castOK = DateTime.TryParse(value.ToString(), out dt)
                          select castOK ? dt : _defaultDateTimeValue).ToArray();
    
    double d = new double();
    double[] yValues = (from item in this.ItemsSource
                        let property = item.GetType().GetProperty(this.YValuesPath)
                        let value = property.GetValue(item)
                        let castOK = double.TryParse(value.ToString(), out d)
                        select castOK ? d : _defaultDoubleValue).ToArray(); 
