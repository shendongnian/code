    using (OpenXmlReader reader = OpenXmlReader.Create(worksheetPart))
    {
        while (reader.Read())
        {
            if (reader.ElementType == typeof(Row))
            {
                do
                {
                    Console.WriteLine("{0} {1} {2}", 
                                      reader.ElementType,
                                      reader.IsStartElement,
                                      reader.IsEndElement);
                } while (reader.Read());
                Console.WriteLine("Finished");
            }
        }
    }
