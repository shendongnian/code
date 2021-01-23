    public class Loan : IXmlSerializable
    {
        public void WriteXml(XmlWriter writer)
        {
            if(dateIn.HasValue)
            {
                writer.WriteElementString("dateIn", dateIn.Value.ToString());
            }
        }
    }
