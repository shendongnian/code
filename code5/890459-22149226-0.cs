    class Animal {}
    class Tiger : Animal {}
    ...
    static void M(Animal animal) {}
    static void M<T>(params T[] items) {}
    ...
    M(new Tiger());
