            System.Globalization.DateTimeFormatInfo dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
            dateTimeFormat.ShortDatePattern = "dd-MMM-yy";
            
            // Add here all the extra types you need to serialize
            Type[] extraTypes = new Type[] { typeof(System.Globalization.GregorianCalendar) };
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(dateTimeFormat.GetType(), extraTypes);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"c:\testso.xml");
            xs.Serialize(sw, dateTimeFormat);
