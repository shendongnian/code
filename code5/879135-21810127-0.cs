    string s = Properties.Settings.Default.ConnectionStr;
    Console.WriteLine("Connection string from main app: " + s);
    //
    // When setting access modifier on Class library to `public`
    //
    s = ClassLibrary1.Properties.Settings.Default.ConnectionStr;
    Console.WriteLine("Connection string from dll: " + s);
