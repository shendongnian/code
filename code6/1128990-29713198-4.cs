    var version = webBrowser.Document.Body.InnerText
       .Split('.') // this splits the string into number parts
       .Select(p => Int32.Parse(p)) // this converts each number part to an int
       .ToArray() // this returns them as an array of integer values.
    // This prints the version components
    if (version.Length == 1)
        Console.WriteLine("Version: {0}", version[0]);
    else if (version.Length == 2) 
        Console.WriteLine("Version: Major = {0}, Minor = {1}", version[0], version[1]);
    else if (version.Length == 3)
        Console.WriteLine("Version: Major = {0}, Minor = {1}, Increment = {2}", version[0], version[1], version[2]);
    else if (version.Length == 3)
        Console.WriteLine("Version: Major = {0}, Minor = {1}, Increment = {2}, BuildNumber = {3}", version[0], version[1], version[2], version[4]);
    else
        Console.WriteLine("Version contains more than 4 ({0}) parts", version.Length);
