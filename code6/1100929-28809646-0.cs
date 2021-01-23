         [Test]
        public void test()
        {
            var a = @"<XML>
            <Field1>sometext</Field1>
            </XML>";
            var b = @"<Table Date ='20150302' Time = '0946'>
           <Row>
           <Field1>sometext</Field1>
           <Field2>2341.5145</Field2>
           </Row>
           </Table>";
            XDocument doc=XDocument.Parse(b);
            PrintAllNodes(doc.Descendants());
        }
        private void PrintAllNodes(IEnumerable<XElement> nodes)
        {
            foreach (var node in nodes)
            {
                foreach (var xAttribute in node.Attributes())
                {
                    Console.WriteLine(xAttribute.Name + ": " + xAttribute.Value);
                }
             
                  Console.WriteLine(node.Name + " " + node.Value);
            }
        }
