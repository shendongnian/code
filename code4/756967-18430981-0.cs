    public void assignData(IEnumerable<ICustomClass> enumerable) {
      foreach (var customData in enumerable) {
        customData.dateAdded = newValue;
      }
    }
