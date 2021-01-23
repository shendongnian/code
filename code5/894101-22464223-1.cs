    using System;
    using System.Diagnostics;
    public static class Program{
    public static void Main()
    {
        PropertyTest propertyTest = new PropertyTest();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        propertyTest.LoopUsingField();
        Console.WriteLine("Using field: " + stopwatch.ElapsedMilliseconds / 1000.0);
        stopwatch.Restart();
        propertyTest.LoopUsingBoxedGetter();
        Console.WriteLine("Using boxed getter: " + stopwatch.ElapsedMilliseconds / 1000.0);
        stopwatch.Restart();
        propertyTest.LoopUsingUnboxedGetter();
        Console.WriteLine("Using unboxed getter: " + stopwatch.ElapsedMilliseconds / 1000.0);
    }
    }
    public class PropertyTest
    {
        public PropertyTest()
        {
            _numRepeat = 1000000000L;
            _field = 1;
            Property = 1;
            IntProperty = 1;
        }
        private long _numRepeat;
        private object _field = null;
        private object Property {get;set;}
        private int IntProperty {get;set;}
        public void LoopUsingBoxedGetter()
        {
            for (long i = 0; i < _numRepeat; i++)
            {
              var f = Property;
            }
        }
        public void LoopUsingUnboxedGetter()
        {
            for (long i = 0; i < _numRepeat; i++)
            {
                var f = IntProperty;
            }
        }
        public void LoopUsingField()
        {
            for (long i = 0; i < _numRepeat; i++)
            {
                var f = _field;
            }
        }
    }
