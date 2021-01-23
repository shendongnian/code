    public static class EnumSizeExtensions {
      public static String ToName(this EnumSize value) {
        switch (value) {
          case EnumSize.Miniscule: 
            return "My Miniscule size";
          case EnumSize.Tiny: 
            return "My Tiny size";
          case EnumSize.Small: 
            return "My small size";
          case EnumSize.Medium:  
            return "My Medium size";
          case EnumSize.Large: 
            return "My Large size"; 
          case EnumSize.Huge: 
            return "My Huge size";
          case EnumSize.Giant: 
            return "My Giant size";
          default:
            return "Unknown";
        }
      }
    }
    
    ...
    
    String temp = pSize.ToName();
