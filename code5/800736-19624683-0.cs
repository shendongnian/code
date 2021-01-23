    string xmlString =
                @"<?xml version=""1.0""?>
                <Employees>
                  <Employee>
                    <EmpId>1</EmpId>
                    <Name>Sam</Name>
                    <Sex>Male</Sex>
                    <Address>
                      <Country>USA</Country>
                      <Zip>95220</Zip>
                    </Address>
                  </Employee>
                  <Employee>
                    <EmpId>2</EmpId>
                    <Name>Lucy</Name>
                    <Sex>Female</Sex>
                    <Address>
                      <Country>USA</Country>
                      <Zip>95220</Zip>
                    </Address>
                  </Employee>
                </Employees>
                ";
                
            System.Xml.Linq.XDocument xmlDoc = System.Xml.Linq.XDocument.Parse(xmlString);
            foreach (var employee in xmlDoc.Descendants("Employee"))
            {
                employee.Descendants("Name").First().Remove();
                employee.Descendants("Address").First().Descendants("Country").First().Remove();
            }
            MessageBox.Show(xmlDoc.ToString());
