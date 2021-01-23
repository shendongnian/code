    class C : IXmlSerializable {
        public double Value { get; set; }
    
        public override string ToString() {
            return Value.ToString(CultureInfo.CurrentCulture);
        }
    
        public string ToString(IFormatProvider provider) {
            return Value.ToString(provider);
        }
    
        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }
    
        public void ReadXml(XmlReader reader) {
            throw new NotImplementedException();
        }
    
        public void WriteXml(XmlWriter writer) {
            writer.WriteElementString("Value", Convert.ToString(Value, CultureInfo.CurrentCulture.NumberFormat));
        }
    }
