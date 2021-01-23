    [Serializable]
    [XmlRoot("Vehicle")]
    public class Vehicle : System.Xml.Serialization.IXmlSerializable
    {
        [XmlElement(IsNullable = true)]
        public string Wheels { get; set; }
        [XmlElement(IsNullable = true)]
        public string Windows { get; set; }
        [XmlElement]
        public int Doors { get; set; }
        [XmlElement]
        public Engine Engine { get; set; }
        [XmlElement]
        public DateTime ManufactureTimestamp { get; set; }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();
            while (reader.Read())
                switch (reader.Name)
                {
                    case "Wheels":
                        Wheels = reader.ReadString();
                        break;
                    case "Windows":
                        Windows = reader.ReadString();
                        break;
                    case "Doors":
                        int doors = 0;
                        int.TryParse(reader.ReadString(), out doors);
                        Doors = doors;
                        break;
                    case "Engine":
                        Engine = (Engine)Enum.Parse(typeof(Engine), reader.ReadString());
                        break;
                    case "ManufactureTimestamp":
                        ManufactureTimestamp = Convert.ToDateTime(reader.ReadString()).ToUniversalTime();
                        break;
                };
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("Wheels", Wheels);
            writer.WriteElementString("Windows", Windows);
            writer.WriteElementString("Doors", Doors.ToString());
            writer.WriteElementString("Engine", Engine.ToString());
            writer.WriteElementString("ManufactureTimestamp", ManufactureTimestamp.ToString("yyyy-MM-ddThh:mm:ss.ffffff"));
        }
        #endregion
    }
