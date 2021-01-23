        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty realProp;
            object property;
            //check if this property already exists
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out property))
            {
                realProp = (HttpRequestMessageProperty) property;
                if (string.IsNullOrEmpty(realProp.Headers["User-Agent"])) //don't modify if it is already set
                {
                    realProp.Headers["User-Agent"] = "doktorinSM/2.1";
                }
                return null;
            }
            realProp = new HttpRequestMessageProperty();
            realProp.Headers["User-Agent"] = "doktorinSM/2.1";
            request.Properties.Add(HttpRequestMessageProperty.Name, realProp);
            return null;
        }
