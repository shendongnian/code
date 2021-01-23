     Collection = Container.MyClass.MyCollection;   //This will trigger the PropertyChangedEvent
     ...
     Container.MyClass = Initialize.BrokenFreshInstance();
     Collection = Container.MyClass.MyCollection;   // Trigger again..
     
