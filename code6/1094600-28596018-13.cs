            try
            {
                // Load the XML from the external site
                XDocument xmlDoc;
                var requestUri = new Uri(uriString);
                HttpWebRequest httprequest = (HttpWebRequest)WebRequest.Create(requestUri);
                using (var httpresponse = (HttpWebResponse)httprequest.GetResponse())
                using (var stream = httpresponse.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    xmlDoc = XDocument.Load(reader);
                }
                // Extract the name & email.
                var people = xmlDoc
                    // Get the "Result" node
                    .Root.Elements(xmlDoc.Root.Name.Namespace + "Result")
                    // Loop through its elements
                    .SelectMany(result => result.Elements())
                    // Deserialize the element name and UserEmail sub-element value as a Person
                    .Select(element => new Person { userName = element.Name.LocalName, userEmail = element.Element(xmlDoc.Root.Name.Namespace + "UserEmail").ValueSafe() })
                    .ToList();
                // Process or return the list of people
            }
            catch (Exception ex)
            {
                // Handle any web exception encountered.
                Debug.WriteLine(ex);
                // Or rethrow if it can't be handled here
                throw;
            }
