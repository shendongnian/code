    public static class valueExtensions {
      public static String ToReport(this value item) {
        switch (item) {
          case value.V1:
            return "V1.0";
          case value.V2:
            return "V2.0";
          case value.V3:
            return "V3.0";
          default:
            return "?"; 
        }
      }
    }
    ...
    value data = value.V1;
    String result = data.ToReport(); // <- "V1.0" 
