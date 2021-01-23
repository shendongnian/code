    class Program
    {
        // A sample xml string.
        static string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                        <AI>
                          <ai>
                            <id>1</id>
                            <name>NAME</name>
                          </ai>
                          <ai>
                            <id>2</id>
                            <name>NAME2</name>
                          </ai>
                          <ai>
                            <id>3</id>
                            <name>NAME3</name>
                          </ai>
                        </AI>";
        static void Main(string[] args)
        {
            // Read the string.
            XElement xelem = XElement.Parse(xml);
            var results = xelem.Descendants("ai")    // Get all <ai> nodes.
                               .Select(x =>
                               new
                               {
                                   // Get values from <id> and <name>.
                                   // Use anonymous types to store the results.
                                   id = x.Descendants("id").First().Value,       
                                   name = x.Descendants("name").First().Value,    
                               });
            // Filter out required result.
            var filtered = results.Where(x => x.name == "NAME").First().id;
        }
    }
