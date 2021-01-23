      public class Survey
      {    
          public string EditLink { get; set; }
      }
      private void SerializeSurvey()
      {
         XmlSerializer serializer = new XmlSerializer(typeof(Survey));
         Survey survey = new Survey(){EditLink=""};
         // Create an XmlTextWriter using a FileStream.
         Stream fs = new FileStream(filename, FileMode.Create);
         XmlWriter writer =  new XmlTextWriter(fs, Encoding.Unicode);
         
         // Serialize using the XmlTextWriter.
         serializer.Serialize(writer, survey);
         writer.Close();
      }
