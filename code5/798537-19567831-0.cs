    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Test {
        public static void Main(String[] args) {
            var l = new List<String>() { "a", "ab", "b", "bb", "bc", "ba", "c", "ca", "cc" };
            foreach (var s in l.Where(e => { Console.WriteLine(e); return e.Contains("a"); }).Take(3)) {
                Console.WriteLine("loop: {0}", s);
            }
        }
    }
