        private string[] ParseLine(string line, char fieldSeparator, char? textSeparator)
        {
            List<string> items = new List<string>();
            StringBuilder itemBuilder = new StringBuilder();
            bool textSeparatorFound = false;
            for (int i = 0; i < line.Length; i++)
            {
                // Get current character
                char currentChar = line[i];
                // In case it is a field separator...
                if (currentChar == fieldSeparator)
                {
                    // a) Did we recognize a quote before => Add the character to the item
                    if (textSeparatorFound)
                    {
                        itemBuilder.Append(currentChar);
                    }
                    // b) We're not within an open quote => We've finished a field
                    else
                    {
                        string item = itemBuilder.ToString();
                        itemBuilder.Remove(0, itemBuilder.Length);
                        // Replace doubled text separators
                        if (textSeparator != null)
                        {
                            string replaceWhat = String.Concat(textSeparator, textSeparator);
                            string replaceWith = textSeparator.ToString();
                            item = item.Replace(replaceWhat, replaceWith);
                        }
                        items.Add(item);
                    }
                }
                // If it is a quote character
                else if (currentChar == textSeparator)
                {
                    // a) If we have no open quotation, we open one
                    if (!textSeparatorFound)
                    {
                        textSeparatorFound = true;
                    }
                    // b) If we have an open quotation we have to decide whether to close it or not
                    else
                    {
                        // If this character is followed by the field separator or the end of the string, 
                        // this ends a quoted block. Otherwise we just add it to the output to
                        // handle quoted quotes.
                        if (i < line.Length - 1 && line[i + 1] != fieldSeparator)
                            itemBuilder.Append(currentChar);
                        else
                            textSeparatorFound = false;
                    }
                }
                // All other characters are appended to the current item
                else
                    itemBuilder.Append(currentChar);
            }
            // All other text is just appended
            if (itemBuilder.Length > 0)
            {
                string item = itemBuilder.ToString();
                itemBuilder.Remove(0, itemBuilder.Length);
                // Remember to replace quoted quotes
                if (textSeparator != null)
                {
                    string replaceWhat = String.Concat(textSeparator, textSeparator);
                    string replaceWith = textSeparator.ToString();
                    item = item.Replace(replaceWhat, replaceWith);
                }
                items.Add(item.Trim());
            }
            return items.ToArray();
        }
