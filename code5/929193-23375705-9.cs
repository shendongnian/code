    void XmlSerializerMemory(List<Test> list)
    {
        var sw = new Stopwatch();
        sw.Start();
        var s = new FileStream("c:\\temp\\test.xmlmem", FileMode.Create);
        var m = new MemoryStream(1024*1024);  // INITIAL BUFFER SIZE (can and will grow!)
        // also works but is slower: var m = new MemoryStream();     
       var x = new XmlSerializer(typeof(List<Test>));
        x.Serialize(m,list);
        
        m.Position=0;
        m.CopyTo(s);
        m.Close();
        s.Close();
        sw.Stop();
        
        sw.Elapsed.Dump("Xml Mem");
    }
    
