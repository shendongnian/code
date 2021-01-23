        // Private state 
    
        private string personName;
    
    
        // Constructors 
    
        public Person (string name)
        {
            personName = name;
        }
    
        public Person ()
        {
            personName = null;
        }
    
    
        // Xml Serialization Infrastructure 
    
        public void WriteXml (XmlWriter writer)
        {
            writer.WriteString(personName);
        }
    
        public void ReadXml (XmlReader reader)
        {
            personName = reader.ReadString();
        }
    
        public XmlSchema GetSchema()
        {
            return(null);
        }
    
    
        // Print 
    
        public override string ToString()
        {
            return(personName);
        }
    
    }
