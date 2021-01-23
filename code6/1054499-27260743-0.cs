    class Program
    {
        static void Main(string[] args)
        {
            string xmldata = @"<Z_STU_CRS_TRNS_DOC xmlns=""http://testurl"">
    <Z_STATUS_CODE>0</Z_STATUS_CODE>
    <Z_STATUS_MSG>Success</Z_STATUS_MSG>
    <Z_STUDENT_ID_SUB_DOC xmlns=""http://testurl"">
        <Z_STU_ID>000999999</Z_STU_ID>
    </Z_STUDENT_ID_SUB_DOC>
    <Z_CRSE_SUB_DOC xmlns=""http://testurl"">
        <Z_COURSE xmlns=""http://testurl"">
            <Z_CRSE_DATA>9999|199901|TEST|9999|1|S|Scuba Diving| |XX</Z_CRSE_DATA>
        </Z_COURSE>
        <Z_COURSE xmlns=""testurl"">
            <Z_CRSE_DATA>9999|200001|TEST|999|3|A|English 101| |XX</Z_CRSE_DATA>
        </Z_COURSE>
    </Z_CRSE_SUB_DOC>
    </Z_STU_CRS_TRNS_DOC>";
            string errorTag = "Z_STATUS_CODE",
                statusTag = "Z_STATUS_MSG";
            XDocument xml = XDocument.Parse(xmldata);
            XNamespace ns = "http://testurl";
            int errorCode = -1;
            string statusMessage = string.Empty;
            using (XmlReader reader = xml.CreateReader())
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }
                    if (!string.Equals(reader.Name, errorTag) &&
                        !string.Equals(reader.Name, statusTag))
                    {
                        continue;
                    }
                    string currentName = reader.Name;
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.EndElement)
                        {
                            break;
                        }
                        if (reader.NodeType != XmlNodeType.Text)
                        {
                            continue;
                        }
                        if (string.Equals(currentName, errorTag))
                        {
                            errorCode = int.Parse(reader.Value);
                        }
                        if (string.Equals(currentName, statusTag))
                        {
                            statusMessage = reader.Value;
                        }
                        break;
                    }
                }
            }
            if (errorCode == -1)
            {
                // no tag found
                Console.WriteLine("No tag found named: {0}", errorTag);
            }
            else if (errorCode == 0)
            {
                Console.WriteLine("Operation was a success!");
            }
            else
            {
                Console.WriteLine("Operation failed with error code {0}", errorCode);
            }
            if (!string.IsNullOrWhiteSpace(statusMessage))
            {
                Console.WriteLine("Status message: {0}", statusMessage);
            }
            Console.ReadLine();
        }
    }
