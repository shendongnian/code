        using (var rdr = new StringReader(Properties.Resources.Testing)) {
            string line;
            while ((line = rdr.ReadLine()) != null) {
                // Do something with line
                //...
            }
        }
