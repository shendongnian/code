    public void assignData(IEnumerable<object> enumerable) {
      foreach (dynamic customData in enumerable) {
        try { 
          customData.dateAdded = newValue;
        } catch { 
          // Object doesn't have dateAdded so just move on
        }
      }
    }
