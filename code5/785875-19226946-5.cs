    SpecialFactory specialFactory = new SpecialFactory();
    SubclassOfDriver subclassDriver = specialFactory.New(); // Fine
    IDriverFactory generalFactory = specialFactory;
    IDriver generalDriver = generalFactory.New(); // Fine
    // This wouldn't compile
    SubclassOfDriver invalid = generalFactory.New();
