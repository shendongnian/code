     String source = ...;
     DateTime result;
     if (DateTime.TryParseExact(source, "yyyy-MM-dd", 
                                CultureInfo.InvariantCulture, 
                                out result) {
       // parsed
     }
     else {
       // not parsed (incorrect format)
     }
