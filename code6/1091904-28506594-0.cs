    private String GetRequestBody(ref Message message)
        {
            MessageBuffer buffer = message.CreateBufferedCopy(Int32.MaxValue);
            message = buffer.CreateMessage();
            String xml = null;
            try
            { 
                var copy = buffer.CreateMessage();
                var dicReader = copy.GetReaderAtBodyContents();
                xml = dicReader.ReadOuterXml();
            }
            catch (Exception e)
            {
            }
            return xml;
    }
