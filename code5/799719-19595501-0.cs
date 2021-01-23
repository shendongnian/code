    if (error is XmlSchemaValidationException && fault == null)
            {
                fault = Message.CreateMessage(version, new FaultException().CreateMessageFault() , "error");
                fault.Properties[HttpResponseMessageProperty.Name] = new HttpResponseMessageProperty
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    SuppressEntityBody = true
                };
                return;
            }
