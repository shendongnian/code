    // the below approach is essential to getting the right assembly
    var assembly = typeof(TestClass).GetTypeInfo().Assembly;
    // Use this help aid to figure out what the actual manifest resource name is. 
    // can be removed later
    string[] resources = assembly.GetManifestResourceNames();
    // Once you figure out the name from the string array above, pass it in as the argument here.
    // . replaces /
    Stream stream = assembly.GetManifestResourceStream("TestMockJson.Mock.TestFile.Json");
    var sr = new StreamReader(stream);
    return sr.ReadToEnd();
