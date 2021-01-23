    using (TextReader sampleTextReader = new StringReader(txtInput.Text)) // Change this whereever you get the XML string from
    {
      XmlSerializer sampleXmlSeri = new XmlSerializer(typeof(ODATAException));
      ODATAException newExc = sampleXmlSeri.Deserialize(sampleTextReader) as ODATAException;
      if (newExc != null)
      {
        // Do something with the error
      }
    }
