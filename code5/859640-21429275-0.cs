    /// <summary>
        /// Compare two objects, returns destination object with matched properties, values. simply Reflection to automatically copy and compare properties of two object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns>destination</returns>
        public static object CompareNameAndSync(object source, object destination)
        {
            Type stype = source.GetType();
            Type dtype = destination.GetType();
            PropertyInfo[] spinfo = stype.GetProperties();
            PropertyInfo[] dpinfo = dtype.GetProperties();
            foreach (PropertyInfo des in dpinfo)
            {
                foreach (PropertyInfo sou in spinfo)
                {
                    if (des.Name == sou.Name)
                    {
                        des.SetValue(destination, sou.GetValue(source));
                    }
                }
            }
            return destination;
        }
