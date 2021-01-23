    var data = new ObservableCollection<Test>();  
    data.Add(new Test {test1="abc", test2="abc2", test3="abc3"});  
    data.Add(new Test {test1="bc", test2="bc2", test3="bc3"});  
    data.Add(new Test {test1="c", test2="c2", test3="c3"}); 
    Data = data
----
    public ObservableCollection<Test> Data {get;set;}
 
