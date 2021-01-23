    var myHolder = new MyHolder {
    	Parts = new List<MyPart> {
    		new MyPart { Id = 7, Taken = true, Name = "Test" },
    		new MyPart { Id = 8, Taken = false, Name = "Test 1" }
    	}
    };
		
    var before = myHolder.Parts.Where(e => e.Taken).Select(f => f.Id).ToList();
    Console.WriteLine(before.Count());
    		
    myHolder.Parts.First(p => p.Id == 7).Taken = false;
    		
    var after = myHolder.Parts.Where(e => e.Taken).Select(f => f.Id).ToList();
    Console.WriteLine(after.Count());
