		/* Using the codepage 1252 doesn't solve the 8bit ASCII problem :/
		   any help would be appreciated.
		 
		  // get encoding for latin characters (like ö, ü, ß or ô)
		  static Encoding ecp1252 = Encoding.GetEncoding(1252);
		*/
        // private static Encoding _encoding = System.Text.ASCIIEncoding;
        private static Encoding _encoding = System.Text.Encoding.GetEncoding(850);
