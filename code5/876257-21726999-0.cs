        private static bool isXmlParse(string inputXml, out string exceptionMsg)
        {
            // TODO: Career warning - implementing workarounds instead of real fixes may harm your career.
            try
            {
                var d = new XmlDocument();
                d.LoadXml(inputXml);
                exceptionMsg = null;
            }
            catch (XmlException ex)
            {
                exceptionMsg = ex.Message;
                if (ex.Message.StartsWith("An error occurred while parsing EntityName"))
                    return true;
            }
            return false;
        }
