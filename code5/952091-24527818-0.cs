      private string ExtractMessage(Exception e)
        {
            var doc = XDocument.Parse(e.InnerException.Message);
            var nspace = doc.Root.GetNamespaceOfPrefix("m"); // .GetDefaultNamespace();
            var msg = from node in doc.Root.Elements(nspace + "innererror")
                        .Elements(nspace + "internalexception")
                        .Elements(nspace + "message")
                      select node.Value;
            return msg.LastOrDefault();
        }
