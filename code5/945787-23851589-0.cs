    public static class SolidWorksExtensions
    {
        public static void writeXml(this SketchPoint point, 
            XmlWriter writer, string nameElement)
        {
            writer.WriteStartElement(nameElement);
            writer.WriteString(Convert.ToString(point.X * 1000.0) + ", ");
            writer.WriteString(Convert.ToString(point.Y * 1000.0) + ", ");
            writer.WriteString(Convert.ToString(point.Z * 1000.0));
            writer.WriteEndElement();
        }
    }
 
