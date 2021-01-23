        class Program {
            static void Main(string[] args) {
                var xml = @"
    <Root>
      <System>
        <ID>1</ID>
        <Name>one</Name>
        <Monitor>
          <ID>3</ID>
          <Type>t3</Type>
          <Alert>
            <ID>5</ID>
            <Status>a5</Status>
          </Alert>
          <Alert>
            <ID>6</ID>
            <Status>a6</Status>
          </Alert>
        </Monitor>
      </System>
      <System>
        <ID>2</ID>
        <Name>two</Name>
        <Monitor>
          <ID>4</ID>
          <Type>t4</Type>
          <Alert>
            <ID>7</ID>
            <Status>a7</Status>
          </Alert>
        </Monitor>
      </System>
    </Root>
    ";
                XElement xmlDoc = XElement.Parse(xml);
                // set q to an enumeration of XElements
                // where the elements xname is "System"
                // the query actually executes the first time q is used
                var q = xmlDoc.Elements("System");
                foreach (var ele in q) {
                    // Get the value of the Element with the xname of "ID"
                    Console.WriteLine(ele.Element("ID").Value); 
                    Console.WriteLine(ele.Element("Name").Value);
                    // if ele.Elements("Monitor") returns nothing
                    // then the foreach will be skipped (null-execution)
                    foreach (var mon in ele.Elements("Monitor")) {
                        Console.WriteLine(mon.Element("ID").Value);
                        Console.WriteLine(mon.Element("Type").Value);
                        foreach (var alert in mon.Elements("Alert")) {
                            Console.WriteLine(alert.Element("ID").Value);
                            Console.WriteLine(alert.Element("Status").Value);
                            }
                        }
                    }
                }
            }
