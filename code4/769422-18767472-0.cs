    class SourceClass
    {
        public string Stringphoneno { get; set; }
    }
    
    class DestinationClass
    {
        public int IntphoneNo { get; set; }
    }
    
    var source = new SourceClass {Stringphoneno = "8675309"};
    var destination = Mapper.Map<SourceClass, DestinationClass>(source);
    
    Console.WriteLine(destination.IntphoneNo); //8675309
