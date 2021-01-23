    public class Program
    {
        public void Main(){
            foreach(var p in getLine().Select(s => s).GroupAt(3))
                Console.WriteLine(p.Aggregate("",(s,val) => s += val));
        }
        public string getLine(){ return "Hello World, how are you doing, this just some text to show how the grouping works"; }
    }
