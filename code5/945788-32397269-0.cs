    public class SketchPointWriter
    {
       private SketchPoint _sketchPoint;
    
       public SketchPointWriter(SketchPoint sketchPoint)
       {
           _sketchPoint = sketchPoint;
       }
    
       public void writeXml(XmlWriter writer, string nameElement)
        {
            writer.WriteStartElement(nameElement);
            writer.WriteString(Convert.ToString(_sketchPoint.X * 1000.0) + ", ");
            writer.WriteString(Convert.ToString(_sketchPoint.Y * 1000.0) + ", ");
            writer.WriteString(Convert.ToString(_sketchPoint.Z * 1000.0));
            writer.WriteEndElement();
        }
    }
