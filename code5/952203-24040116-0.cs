     public static void Test()
        {
    ...
            using (var writer = new StreamWriter(@"C://testLoggfile.xml"), true) // this will append line at the end of file.
            {
                dd.WriteObject(writer.BaseStream, infos);
            }
        }
    ...
