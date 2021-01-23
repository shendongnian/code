        /// <summary>
        /// This method is used to get the individual inner value of the specified element.
        /// </summary>
        /// <param name="element">Contains the XElement to retrieve a value.</param>
        /// <returns>Returns only the inner value of the element specified.</returns>
        /// <remarks>
        /// XElement.Value returns a concatenated string of all child element values. This is bad if
        /// only the inner text value of the specified element is required.
        /// </remarks>
        public static string InnerValue(this XElement element)
        {
            // get the last child node of NodeType = Text...
            var textNode = element.Nodes().OfType<XText>().LastOrDefault();
    
            // return the value of the text node if found
            return textNode != null ? textNode.Value : string.Empty;
        }
