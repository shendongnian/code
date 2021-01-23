    using System;
    using CompilerServiceTest;
    public class LalaDynamicImpl : ILala
    {
        private static int _counter;
        public void DoLala()
        {
            _counter++;
        }
    }
