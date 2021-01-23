    List<Test> list = new List<Test>();
    
    list.Add(new Test { Id = 1, Name = "Tom" });
    list.Add(new Test { Id = 2, Name = "Mark" });
    
    using (var w = new ChoCSVWriter<Test>(Console.Out)
    	.WithFirstLineHeader()
    	)
    {
    	w.Write(list);
    }
