    if isConcreteType(myType) {
        DoSomething();
    }
    bool isConcreteType(Type type) {
        return type.IsClass && !type.IsAbstract;
    }
