    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    class Program
    {
        static void Main()
        {
            string savedGame = @"
    <SaveGameData xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
      <properties>
        <PropertyContainer>
          <property xsi:type='DerivedProperty'>
            <BasePropertyData>1</BasePropertyData>
            <DerivedPropertyData>1</DerivedPropertyData>
          </property>
        </PropertyContainer>
      </properties>
    </SaveGameData>";
            XmlSerializer serializer = new XmlSerializer(typeof(SaveGameData));
            SaveGameData result;
            using (StringReader stream = new StringReader(savedGame))
            {
                result = (SaveGameData)serializer.Deserialize(stream);
            }
            Console.WriteLine(result.properties[0].property is DerivedProperty); // True
        }
    }
    public class SaveGameData
    {
        public virtual List<PropertyContainer> properties { get; set; }
    }
    public class PropertyContainer
    {
        public Property property { get; set; }//Could be set to DerivedProperty
    }
    [XmlInclude(typeof(DerivedProperty))]
    public class Property
    {
        public int BasePropertyData { get; set; }
    }
    public class DerivedProperty : Property
    {
        public int DerivedPropertyData { get; set; }
    }
