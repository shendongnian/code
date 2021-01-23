    // This gets us looping through the outer nodes
    for (var i = 1; i < possibleNodes.Count - 1; i++) 
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
                        }
                    }
                }
            }
        }
    }
