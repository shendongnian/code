    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace XmlFromTextString
    {
        class Program
        {
            static void Main(string[] args)
            {
                // This simulates text from a file; note that it must be flush to the left of the screen or else the extra spaces 
                // add unneeded nodes to the lists that are generated; for simplicity of code, I chose not to implement clean-up of that and just 
                // ensure that the string literal is not indented from the left of the Visual Studio screen.
                string text =
    @"/home
    /home/room1
    /home/room1/subroom
    /home/room2
    /home/room2/miniroom
    /home/room2/test/thetest
    /home/room2/bigroom
    /home/room2/hugeroom
    /home/room3";
                var possibleNodes = new List<List<string>>();
                var splitLines = text
                    .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                splitLines.ForEach(l => 
                    possibleNodes.Add(l
                        .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                    )
                );
                var nodeDepth = possibleNodes.Max(n => n.Count);
                // Create the root node
                XDocument xDoc = new XDocument(new XElement(possibleNodes[0][0]));
                // We don't need it anymore
                possibleNodes.RemoveAt(0);
                // This gets us looping through the outer nodes
                for (var i = 0; i < possibleNodes.Count; i++)  
                {
                    // Here we go "sideways" by going through each inner list (each broken down line of the text)
                    for (var ii = 1; ii < nodeDepth; ii++)
                    {
                        // Some lines have more depth than others, so we have to check this here since we are looping on the maximum
                        if (ii < possibleNodes[i].Count)
                        {
                            // Let's see if this node already exists
                            var existingNode = xDoc.Root.Descendants().FirstOrDefault(d => d.Name.LocalName == (possibleNodes[i][ii]));
                            // Let's also see if a parent node was created in the previous loop iteration. 
                            // This will tell us whether to add the current node at the root level, or under another node
                            var parentNode = xDoc.Root.Descendants().FirstOrDefault(d => d.Name.LocalName == (possibleNodes[i][ii - 1]));
                            // If the current node has already been added, we do nothing (this if statement is not entered into)
                            // Otherwise, existingNode will be null and that means we need to add the current node
                            if (null == existingNode)
                            {
                                // Now, use parentNode to decide where to add the current node
                                if (null == parentNode)
                                {
                                    // The parent node does not exist; therefore, the current node will be added to the root node.
                                    xDoc.Root.Add(new XElement(possibleNodes[i][ii]));
                                }
                                else
                                {
                                    // There IS a parent node for this node! 
                                    // Therefore, we must add the current node to the parent node 
                                    // (remember, parent node is the previous iteration of the inner for loop on nodeDepth )
                                    var newNode = new XElement(possibleNodes[i][ii]);
                                    parentNode.Add(newNode);
                                    // Add "this is a" text (bonus!) -- only adding this text if the current node is the last one in the list.
                                    if (possibleNodes[i].Count -1 == ii)
                                    {
                                        newNode.Add(new XText("This is a " + newNode.Name.LocalName));
                                        // For the same default text on all child-less nodes, us this:
                                        // newNode.Add(new XText("This is default text"));
                                    }
                                }
                            }
                        }
                    }
                }
                Console.Write(xDoc.ToString());
                Console.ReadKey();
            }
        }
    }
