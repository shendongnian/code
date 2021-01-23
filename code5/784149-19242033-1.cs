    public class MyObjectMapper
    {
        private List<PropertyMapping> myMappings = new List<PropertyMapping>();
        public MyObjectMapper(string xmlFile)
        {
            this.myMappings = GenerateMappingObjectsFromXml(xmlFile);
        }
        /*
         * Actual mapping; iterate over internal mappings and copy each source value to destination value (types have to be the same)
         */ 
        public CalendarEventForm TestMyObjectMapperProjection(CalendarEvent calendarEvent)
        {
            CalendarEventForm calendarEventForm = new CalendarEventForm();
            
            foreach (PropertyMapping propertyMapping in myMappings)
            {
                object originalValue = GetPropValue(calendarEvent,propertyMapping.FromPropertyName);
                SetPropValue(propertyMapping.ToPropertyName, calendarEventForm, originalValue);
            }
            return calendarEventForm;
        }
        /*
         * Get the property value from the source object
         */ 
        private object GetPropValue(object obj, String compoundProperty)
        {
            foreach (String part in compoundProperty.Split('.'))
            {
                if (obj == null) { return null; }
                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }
                obj = info.GetValue(obj, null);
            }
            return obj;
        }
        /*
         * Set property in the destination object, create new empty objects if needed in case of nested structure
         */ 
        public void SetPropValue(string compoundProperty, object target, object value)
        {
            string[] bits = compoundProperty.Split('.');
            for (int i = 0; i < bits.Length - 1; i++)
            {
                PropertyInfo propertyToGet = target.GetType().GetProperty(bits[i]);
                
                propertyToGet.SetValue(target, Activator.CreateInstance(propertyToGet.PropertyType));
                
                target = propertyToGet.GetValue(target, null);               
            }
            PropertyInfo propertyToSet = target.GetType().GetProperty(bits.Last());
            propertyToSet.SetValue(target, value, null);
        }              
        /*
         * Read XML file from the provided file path an create internal mapping objects
         */ 
        private List<PropertyMapping> GenerateMappingObjectsFromXml(string xmlFile)
        {
            XElement definedMappings = XElement.Load(xmlFile);
            List<PropertyMapping> mappings = new List<PropertyMapping>();
            foreach (XElement singleMappingElement in definedMappings.Elements("mapping"))
            {
                mappings.Add(new PropertyMapping(singleMappingElement.Element("src").Value, singleMappingElement.Element("dest").Value));
            }
            return mappings;
        } 
    }
