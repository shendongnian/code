        class XmlResolver : XmlUrlResolver
        {
            internal const string BaseUri = "schema://";
            public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
            {
                if (absoluteUri.Scheme == "schema")
                {
                    switch (absoluteUri.LocalPath)
                    {
                        case "/ADDRESS.xsd":
                            return new MemoryStream(Encoding.UTF8.GetBytes(Resource.ADDRESS));
                        case "/PERSON.xsd":
                            return new MemoryStream(Encoding.UTF8.GetBytes(Resource.PERSON));
                    }
                }
                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
        }
