        public void Compare(object first,object second, object result)
        {
            Type t = first.GetType();
            PropertyInfo[] propertyInfoList =  t.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfoList)
            {
                object value1=  propertyInfo.GetValue(first, null);
                object value2 = propertyInfo.GetValue(second, null);
                if (value1 != value2)
                {
                    propertyInfo.SetValue(result, value1, null);
                }
                else
                {
                   propertyInfo.SetValue(result, null, null);
                }
            }
        }
