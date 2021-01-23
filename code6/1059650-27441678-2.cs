            /// <summary>
        /// Create 3D array of the XML response
        /// </summary>
        /// <param name="inputXML">string XML file</param>
        /// <returns>3D string array of the XML file</returns>
        public static String[,,] GetVars(string inputXML)
        {
            try
            {
                XDocument doc = XDocument.Parse(inputXML);
                if (doc.Root.Elements().Attributes().Count() < 1 || ErrorMessage(doc)) return new string[1, 1, 1];//temp fix for empty xml files
                int i = 0, j = 0, k = 0, elementscounter = doc.Root.Elements().Count(), attributescounter = doc.Root.Elements().Attributes().Count();
                string[,,] vars = new string[elementscounter, ((attributescounter / elementscounter) + getMaxNodes(doc)), getMaxNodesAttributes(doc)];
                foreach (XElement element in doc.Root.Elements())
                {
                    foreach (XAttribute attribute in element.Attributes())
                    {
                        vars[i, j, 0] = TrimVar(attribute.ToString());
                        j++;
                    }
                    foreach (XElement node in element.Nodes())
                    {
                        foreach (XAttribute eAttribute in node.Attributes())
                        {
                            vars[i, j, k] = TrimVar(eAttribute.ToString());
                            k++;
                        }
                        k = 0;
                        j++;
                    }
                    j = 0;
                    i++;
                }
                return vars;
            }
            catch (System.Xml.XmlException)
            {
                string[,,] vars = new string[1, 1, 1];
                vars[0, 0, 0] = "No XML found!";
                return vars;
            }
        }
            /// <summary>
            /// get the max nodes available by a Node
            /// </summary>
            /// <param name="XML">XML string</param>
            /// <returns>Max nodes available</returns>
            private static Int32 getMaxNodes(XDocument XML)
            {
                int max = 1;
                foreach (XElement element in XML.Root.Elements())
                {
                    if(element.Nodes().Count() > max) max = element.Nodes().Count();
                }
                return max;
            }
    
            /// <summary>
            /// get the max attributes available by a Node
            /// </summary>
            /// <param name="XML">XML string</param>
            /// <returns>Max attributes available</returns>
            private static Int32 getMaxNodesAttributes(XDocument XML)
            {
                int max = 1;
                foreach (XElement element in XML.Root.Elements())
                {
                    foreach (XElement node in element.Nodes())
                    {
                        if (node.Attributes().Count() > max) max = node.Attributes().Count();
                    }
                }
                return max;
            }
    
            /// <summary>
            /// Trim the input string to only the value
            /// </summary>
            /// <param name="input">XML readout var</param>
            /// <returns>value of the XML readout var</returns>
            private static String TrimVar(string input)
            {
                return input.Remove(0, (input.IndexOf('"'))+1).TrimEnd('"');
            }
