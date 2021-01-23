    Person mike = new Person { Name = "Mike" };
    mike.Parent = mike;
    var clone = Serializer.DeepClone(mike);
    bool areSamePersonObject = ReferenceEquals(clone, clone.Parent);
    // ^^^ true
