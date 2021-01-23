    class MyClassTypeDescriptors : CustomTypeDescriptor
    {
        Type typeProp;
        
        public MyClassTypeDescriptors(ICustomTypeDescriptor parent, Type type)
            : base(parent)
        {
            typeProp = type;
        }
        //This method will add the additional properties to the object.  
        //It helps to think of the various PropertyDescriptors are columns in a database table
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection cols = base.GetProperties(attributes);
            string propName = ""; //empty string to be populated later
            //find the matching property in the type being called.
            foreach (PropertyDescriptor col in cols)
            {
                if (col.PropertyType.Name == typeProp.Name)
                    propName = col.Name;
            }
            PropertyDescriptor pd = cols[propName];
            PropertyDescriptorCollection children = pd.GetChildProperties(); //expand the child object
            
            PropertyDescriptor[] propDescripts = new PropertyDescriptor[cols.Count + children.Count];
            int count = cols.Count; //start adding at the last index of the array
            cols.CopyTo(propDescripts, 0);
            //creation of the 'descriptor strings'
            foreach (PropertyDescriptor cpd in children)
            {
                propDescripts[count] = new SubPropertyDescriptor(pd, cpd, pd.Name + "_" + cpd.Name);
                count++;
            }
            PropertyDescriptorCollection newCols = new PropertyDescriptorCollection(propDescripts);
            return newCols;
        }
    }
