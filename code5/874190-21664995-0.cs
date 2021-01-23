    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace MultiSorting {
        class Program {
            static void Main() {
    
                const int n = 2;
                const int m = 10;
    
                var keys = GenerateKeys(m);
                foreach (var key in keys) {
                    Console.Write(key + " "); 
                }
                Console.WriteLine("");
                var keysBuffer = new int[keys.Length];
                Array.Copy(keys, keysBuffer, keys.Length);
                Array.Sort(keysBuffer);
                foreach (var key in keysBuffer) {
                    Console.Write(key + " "); 
                }
                Console.WriteLine("");
                // warm up, check that output is the same
                List<string[]> outer = MultiSortNaiveInPlace(keys, GenerateOuter(n, m));
                PrintResults(outer);
                outer = MultiSortNaiveCopy(keys, GenerateOuter(n, m));
                PrintResults(outer);
                outer = MultiSortReuseMapInPlace(keys, GenerateOuter(n, m));
                PrintResults(outer);
                outer = MultiSortReuseMapCopy(keys, GenerateOuter(n, m));
                PrintResults(outer);
                outer = MultiSortLinqCopy(keys, GenerateOuter(n, m));
                PrintResults(outer);
    
                // tests
                keys = GenerateKeys(500);
                NaiveInPlace(2000, 500, keys);
                ReuseMapInPlace(2000, 500, keys);
                NaiveCopy(2000, 500, keys);
                ReuseMapCopy(2000, 500, keys);
                LinqCopy(2000, 500, keys);
    
                Console.ReadLine();
            }
    
            private static void NaiveInPlace(int n, int m, int[] keys) {
                const int rounds = 10;
                var source = new List<List<string[]>>(rounds);
                for (int i = 0; i < rounds; i++) {
                    source.Add(GenerateOuter(n, m));
                }
                GC.Collect();
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < rounds; i++) {
                    source[i] = MultiSortNaiveInPlace(keys, source[i]);
                }
                sw.Stop();
                Console.WriteLine("NaiveInPlace: " + sw.ElapsedMilliseconds);
    
            }
    
            private static void ReuseMapInPlace(int n, int m, int[] keys) {
                const int rounds = 10;
                var source = new List<List<string[]>>(rounds);
                for (int i = 0; i < rounds; i++) {
                    source.Add(GenerateOuter(n, m));
                }
                GC.Collect();
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < rounds; i++) {
                    source[i] = MultiSortReuseMapInPlace(keys, source[i]);
                }
                sw.Stop();
                Console.WriteLine("ReuseMapInPlace: " + sw.ElapsedMilliseconds);
    
            }
    
            private static void NaiveCopy(int n, int m, int[] keys) {
                const int rounds = 10;
                var source = new List<List<string[]>>(rounds);
                for (int i = 0; i < rounds; i++) {
                    source.Add(GenerateOuter(n, m));
                }
                GC.Collect();
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < rounds; i++) {
                    source[i] = MultiSortNaiveCopy(keys, source[i]);
                }
                sw.Stop();
                Console.WriteLine("NaiveCopy: " + sw.ElapsedMilliseconds);
    
            }
    
            private static void ReuseMapCopy(int n, int m, int[] keys) {
                const int rounds = 10;
                var source = new List<List<string[]>>(rounds);
                for (int i = 0; i < rounds; i++) {
                    source.Add(GenerateOuter(n, m));
                }
                GC.Collect();
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < rounds; i++) {
                    source[i] = MultiSortReuseMapCopy(keys, source[i]);
                }
                sw.Stop();
                Console.WriteLine("ReuseMapCopy: " + sw.ElapsedMilliseconds);
    
            }
    
            private static void LinqCopy(int n, int m, int[] keys) {
                const int rounds = 10;
                var source = new List<List<string[]>>(rounds);
                for (int i = 0; i < rounds; i++) {
                    source.Add(GenerateOuter(n, m));
                }
                GC.Collect();
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < rounds; i++) {
                    source[i] = MultiSortLinqCopy(keys, source[i]);
                }
                sw.Stop();
                Console.WriteLine("LinqCopy: " + sw.ElapsedMilliseconds);
    
            }
    
            private static void PrintResults(List<string[]> outer) {
    
                for (var i = 0; i < outer.Count; i++) {
                    foreach (var item in outer[i]) {
                        Console.Write(item + " "); // a{i}, b{i}, c{i}, d{i}, e{i}
                    }
                    Console.WriteLine("");
                }
    
            }
    
            private static int[] GenerateKeys(int m) {
                var keys = new int[m];
                for (int i = 0; i < m; i++) { keys[i] = i; }
                var rnd = new Random();
                keys = keys.OrderBy(x => rnd.Next()).ToArray();
                return keys;
            }
    
            private static List<string[]> GenerateOuter(int n, int m) {
                var outer = new List<string[]>(n);
    
                for (var o = 0; o < n; o++) {
                    var inner = new string[m];
                    for (int i = 0; i < m; i++) { inner[i] = "R" + o + "C" + i; }
                    outer.Add(inner);
                }
                return outer;
            }
    
            private static List<string[]> MultiSortNaiveInPlace(int[] keys, List<string[]> outer) {
                var keysBuffer = new int[keys.Length];
                foreach (var inner in outer) {
                    Array.Copy(keys, keysBuffer, keys.Length);
                    // doing sort N times, but we know the map 
                    // old_index -> new_index from the first sorting
                    // plus we sort keysBuffer N times but use the result only one time
                    Array.Sort(keysBuffer, inner);
                }
                return outer;
            }
    
            private static List<string[]> MultiSortNaiveCopy(int[] keys, List<string[]> outer) {
                var result = new List<string[]>(outer.Count);
                var keysBuffer = new int[keys.Length];
    
                for (var n = 0; n < outer.Count(); n++) {
                    var inner = outer[n];
                    var newInner = new string[keys.Length];
                    Array.Copy(keys, keysBuffer, keys.Length);
                    Array.Copy(inner, newInner, keys.Length);
                    // doing sort N times, but we know the map 
                    // old_index -> new_index from the first sorting
                    // plus we sort keysBuffer N times but use the result only one time
                    Array.Sort(keysBuffer, newInner);
                    result.Add(newInner);
                }
                return result;
            }
    
            private static List<string[]> MultiSortReuseMapInPlace(int[] keys, List<string[]> outer) {
                var itemsBuffer = new string[keys.Length];
                var keysBuffer = new int[keys.Length];
                Array.Copy(keys, keysBuffer, keysBuffer.Length);
                var map = new int[keysBuffer.Length];
                for (int m = 0; m < keysBuffer.Length; m++) {
                    map[m] = m;
                }
                Array.Sort(keysBuffer, map);
    
                for (var n = 0; n < outer.Count(); n++) {
                    var inner = outer[n];
                    for (int m = 0; m < map.Length; m++) {
                        itemsBuffer[m] = inner[map[m]];
                    }
                    Array.Copy(itemsBuffer, outer[n], inner.Length);
                }
                return outer;
            }
    
            private static List<string[]> MultiSortReuseMapCopy(int[] keys, List<string[]> outer) {
                var keysBuffer = new int[keys.Length];
                Array.Copy(keys, keysBuffer, keysBuffer.Length);
                var map = new int[keysBuffer.Length];
                for (int m = 0; m < keysBuffer.Length; m++) {
                    map[m] = m;
                }
                Array.Sort(keysBuffer, map);
                var result = new List<string[]>(outer.Count);
                for (var n = 0; n < outer.Count(); n++) {
                    var inner = outer[n];
                    var newInner = new string[keys.Length];
                    for (int m = 0; m < map.Length; m++) {
                        newInner[m] = inner[map[m]];
                    }
                    result.Add(newInner);
                }
                return result;
            }
    
            private static List<string[]> MultiSortLinqCopy(int[] keys, List<string[]> outer) {
                var result = outer.Select(arr => arr.Select((item, inx) => new { item, key = keys[inx] })
                                        .OrderBy(x => x.key)
                                        .Select(x => x.item)
                                        .ToArray()) // allocating
                      .ToList(); // allocating
                return result;
            }
    
        }
    }
