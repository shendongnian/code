    static function Change(int j) { j = 3; }
    static void Main(string[] args) { 
       int i = 2;
       Change(i);
       System.Console.WriteLine(i);
    }
