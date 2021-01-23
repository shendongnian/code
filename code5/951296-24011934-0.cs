    String xmlString =
                @"<bookstore>
                    <book genre='autobiography' publicationdate='1981-03-22' ISBN='1-861003-11-0'>
                        <title>The Autobiography of Benjamin Franklin</title>
                        <author>
                            <first-name>Benjamin</first-name>
                            <last-name>Franklin</last-name>
                        </author>
                        <price>8.99</price>
                    </book>
                </bookstore>";
            // Create an XmlReader
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                if(reader.ReadToFollowing("book"))
                {
                    reader.MoveToFirstAttribute();
                    string genre = reader.Value;
                    Console.WriteLine("The genre value: " + genre);
                }
                else
                {
                    //Do something else
                }
            }
