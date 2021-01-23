    public static String[,] XGetVars(string inputXML)
            {
                XDocument doc = XDocument.Parse(inputXML);
                int i = 0, j = 0, elementscounter = doc.Root.Elements().Count(), attributescounter = doc.Root.Elements().Attributes().Count();
                string[,] vars = new string[elementscounter,(attributescounter/elementscounter)];
                
                foreach (XElement element in doc.Root.Elements())
                {
                    foreach (XAttribute attribute in element.Attributes())
                    {
                        vars[i,j] = attribute.ToString();
                        j++;
                    }
                    j = 0;
                    i++;
                }
                return vars;
            }
