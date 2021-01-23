    // Names changed to be more conventional
    var class1Loader = new XmlFilePersister<MyClass1>("MC1.xml", myTempDirectory");
    var class2Loader = new XmlFilePersister<MyClass2>("MC2.xml", myTempDirectory");
    // Could do all of this in one statement... note that this uses the
    // covariance of IEnumerable<T>
    IEnumerable<ITransferable> class1Results = class1Loader.RetrieveData();
    IEnumerable<ITransferable> class2Results = class1Loader.RetrieveData();
    var allResults = class1Results.Concat(class2Results).ToList();
