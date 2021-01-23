        private static double sumNumericalProperties<T>(T obj)
        {
            var result = 0d;
            foreach (var prop in typeof (T).GetProperties())
            {
                if (typeof(int).IsAssignableFrom(prop.PropertyType))
                {
                    result += (int)prop.GetValue(obj);
                }
                else if (typeof(double).IsAssignableFrom(prop.PropertyType))
                {
                    result += (double) prop.GetValue(obj);
                }
            }
            return result;
        }
