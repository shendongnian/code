            string response_data = @"<xml_response xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:type=""xsd:string""><![CDATA[<CertificateRequest><ReturnCode>0</ReturnCode><Payload content_type=""application/pdf"" embedded=""base64"">SGVsbG8gV29ybGQ=</Payload></CertificateRequest>]]></xml_response>";
            var element = XElement.Parse(response_data);
            var innerXml = element.Value; // Extract the string literal
            var innerElement = XElement.Parse(innerXml); // Parse the string literal as XML
            var payload = innerElement.Element("Payload").Value; // Extract the payload value
            Debug.Assert(payload == "SGVsbG8gV29ybGQ="); // No assert.
