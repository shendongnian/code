        public virtual void ReadXml(XmlReader reader)
        {
            
            Type type = this.GetType();
            FieldInfo[] pInfo = type.GetFields();
            // Added
            reader.ReadStartElement();
            foreach (FieldInfo property in pInfo)
            {
                object value = null;
                reader.ReadToFollowing(property.Name);
                Type propertyType = property.FieldType;
                value = reader.ReadElementContentAs(property.FieldType, null);
                type.GetField(property.Name).SetValue(this, value);                
            }
            // Added
            reader.ReadEndElement();
        }
        // Serialize
        Type type = typeof(List<Person>); //Changed Type to List of Persons
        XmlSerializer serializer = new XmlSerializer(type);
        TextWriter writer = new StreamWriter(filename);
        serializer.Serialize(writer, list);
        writer.Close();
