    var myList = new List<MyObject>(){
                new MyObject{ FirstColumn = 1, SecondColumn = new List<int>{3,4}},
                new MyObject{ FirstColumn = 2, SecondColumn = new List<int>{3,4}},    
                new MyObject{ FirstColumn = 3, SecondColumn = new List<int>{3,4,5}},    
                new MyObject{ FirstColumn = 5, SecondColumn = new List<int>{3,4}},    
                new MyObject{ FirstColumn = 6, SecondColumn = new List<int>{3,4,7}},    
                new MyObject{ FirstColumn = 7, SecondColumn = new List<int>{3,4}},    
                new MyObject{ FirstColumn = 8, SecondColumn = new List<int>{3,4,5}},    
                new MyObject{ FirstColumn = 9, SecondColumn = new List<int>{3,4,5}}
            };
    var group = myList.GroupBy(x => String.Join("|",x.SecondColumn), x => x.FirstColumn);
    foreach(var i in group)
        Console.WriteLine( String.Join(",",i));
