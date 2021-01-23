        /// <summary>
    /// Class MessageTransform.
    /// </summary>
    public static class MessageTransform
    {
        /// <summary>
        /// Gets the envelope.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>XDocument.</returns>
        public static XDocument GetEnvelope(Message message)
        {
            using (var memoryStream = new MemoryStream())
            {
                var messageBuffer = message.CreateBufferedCopy(int.MaxValue);
                var xPathNavigator = messageBuffer.CreateNavigator();
                var xmlWriter = XmlWriter.Create(memoryStream);
                xPathNavigator.WriteSubtree(xmlWriter);
                xmlWriter.Flush();
                xmlWriter.Close();
                memoryStream.Position = 0;
                var xdoc = XDocument.Load(XmlReader.Create(memoryStream));
                return xdoc;
            }           
        }
        /// <summary>
        /// Gets the header.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>XNode.</returns>
        public static XNode GetHeader(Message message)
        {
            var xdoc = GetEnvelope(message);
            var strElms = xdoc.DescendantNodes();
            var header = strElms.ElementAt(1);
            return header;
        }
        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="localName">Name of the local.</param>
        /// <param name="namespaceName">Name of the namespace.</param>
        /// <returns>IEnumerable&lt;XElement&gt;.</returns>
        public static IEnumerable<XElement> GetBody(Message message, string localName, string namespaceName)
        {
            var xdoc = GetEnvelope(message);
            var elements = xdoc.Descendants(XName.Get(localName, namespaceName));
            
            return elements;
        }
    }
