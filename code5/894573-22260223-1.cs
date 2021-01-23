    // prepare your little filter
    private static readonly Type[] allowedTypes = new Type[] { 
        typeof(bool), typeof(string), typeof(int), 
        typeof(decimal), typeof(DateTime)
    };
    public List<string> BuildParametersFromObject(clsBook oBook, clsStudent oStud)
    {
        List<string> lstRetVal = new List<string>();
        string sTemp = "";
        string sPropType = "";
        int ii;
        if (oBook == null)
        {
            PropertyInfo[] ObjProperties = typeof(clsStudent).GetProperties();
            foreach (PropertyInfo StudProp in ObjProperties)
            {
                // if the property's type is not one of the 5 magnificence
                // simply jump to the next cycle of the foreach loop
                if (!allowedTypes.Contains(StudProp.PropertyType)) 
                    continue;
 
                object pureValue = StudProp.GetValue(oStud);
                // what you were using is not ok: StudProp.GetValue(clsStudent)
                // because you're trying to retrieve the value of a property
                // defined by the clsStudent class
                // and in the process you also need to point out an instance
                // of that particular class, but instead of doing that
                // you were pointing out an instance of Type i.e. clsStudent itself
             
                string stringValue = pureValue + "";
                // simply concatenate the pureValue with a blank string
                // (allowing imminent nulls to be displayed as empty strings instead of crashing your thread with NullReferenceException)
                lstRetVal.Add(stringValue);
                // just add your stringified value to the list
            }
        }
        return lstRetVal;
    }
