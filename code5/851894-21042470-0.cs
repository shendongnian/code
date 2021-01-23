      // Let argument be in the camel case, "className" not "ClassName"
      public ObservableCollection<ParentNode> CreateTreeViewCollection(string className)
      {
        // property "ClassName" is a clone of argument "className"
        EnumerateFullData AllData = 
          new EnumerateFullData() { ClassName = className.Clone() };
      }
