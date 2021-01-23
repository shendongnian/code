    using (var reader = new StreamReader("c:\\test\\testinput.txt"))
    {
        var numColumns = int.Parse(reader.ReadLine());
        while (numColumns-- > 0)
        {
            var colDescription = reader.ReadLine();
            // do stuff
        }
    
        // write everything else to another file.
        File.WriteAllText("c:\\test\\testoutput.txt", reader.ReadToEnd());
    }
