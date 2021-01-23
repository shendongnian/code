    testUI_root theReturn = null;
    System.Xml.Serialization.XmlSerializer s = null;
    using (System.IO.FileStream fs = new System.IO.FileStream(thePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
    	if (fs.Length > 0) {
    		using (System.Xml.XmlTextReader r = new XmlTextReader(fs)) {
    			s = new System.Xml.Serialization.XmlSerializer(typeof(testUI_root));
    			theReturn = (testUI_root)s.Deserialize(r);
    		}
    	}
    }
    return theReturn;
