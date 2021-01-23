    var xml = XElement.Parse(@"<root>
                                 <key>
                                   <id>v1</id>
                                   <val>v2</val>
                                   <iv>v3</iv>
                                 </key>
                               </root>");
    var key = xml.Elements("key").First(x => x.Element("id").Value == "v1");
    Console.WriteLine("val: " + key.Element("val").Value);
    Console.WriteLine(" iv: " + key.Element("iv").Value);
