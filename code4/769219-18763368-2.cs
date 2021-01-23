    string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <RootLevel> <!--Container-->
                       <ListOfOne> <!--List of One -->
                          <One>
                            <ListOfTwo> <!--List of Two -->
                               <Two></Two>
                            </ListOfTwo> 
                         </One>
                       </ListOfOne>
                     </RootLevel>";
    var stream = new MemoryStream(Encoding.Default.GetBytes(xml));
    using (var reader = XmlDictionaryReader
                               .CreateTextReader(stream, 
                                                 new XmlDictionaryReaderQuotas()))
    {
        DataContractSerializer ser = new DataContractSerializer(typeof(RootLevel));
        var deserializedPerson = (RootLevel)ser.ReadObject(reader, true);
        Assert.IsTrue(deserializedPerson.ListOfOne[0].ListOfTwo.Count > 0);
        reader.Close();
    }
