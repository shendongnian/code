    static void Main() {
        var array = new[] {"A", "A", "A", "B", "B", "B", "B", "C", "C", "D"};
        var result = new Collection<string>();
        
        //as u call it "resolution":
        const int resolution = 10;
        
        var currentSymbol = array[0];
        var startIndex = 1;
        
        for (var index = 0; index < array.Length; index++) {
            if (currentSymbol != array[index]) {
                result.Add(currentSymbol + " " + startIndex*resolution + "%-" +index*resolution );
                currentSymbol = array[index];
                startIndex = index + 1;                  
            }
            if (index + 1 == array.Length) {
                result.Add(currentSymbol + " " + startIndex * resolution + "%-" + (index + 1) * resolution);
                currentSymbol = array[index];
                startIndex = index + 1;    
            }
        }
        
        foreach (var a in result) {
            Console.WriteLine(a);
        }
        Console.ReadLine();
    }
