    class UseDelayedValues
    {
        Func<int> x;
        public UseDelayedValues(Func<int> x)
        {
           this.x = x;
        }
 
        public UseWithX(int other)
        {
           return other + x();
        }
    }
    int value = 0;
    var r = new UseDelayedValues(() => value);
    value = 42;// get some value 
    Console.WriteLine(r.UseDelayedValues(1));
    var delayedFromTextbox = new UseDelayedValues(() => int.Parse(textBox1.Value));
      
