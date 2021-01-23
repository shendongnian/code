    var xml = @"
                <root>
                   <Object type=""element"">
                      <Property name=""test1"" value=""testvalue1""/>
                      <Property name=""test2"" value=""testvalue2""/>
                      <Property name=""test3"" value=""testvalue3""/>
                   </Object>
                   <Object type=""element"">
                      <Property name=""name1"" value=""somevalue1""/>
                      <Property name=""name2"" value=""somevalue2""/>
                      <Property name=""name3"" value=""somevalue3""/>
                    </Object>
                 </root>";
    var att = XDocument.Parse(xml)
                .Descendants("Object")
                .First(ele => ele
                    .Elements()
                    .Any(child => child.Attribute("value").Value == "somevalue2"))
                .Elements()
                .First(ele => ele.
                    Attribute("name").Value == "name1")
                .Attribute("value").Value;
