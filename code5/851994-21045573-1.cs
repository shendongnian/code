    using System;
    using System.Linq;
    namespace WhatWasTheQuestion {
        class Program {
            static readonly int[] prefix = { 0, 0, 3, 8, 8, 15 };
            static readonly int[] suffix = { 0, 3, 2, 7, 7, 9, 12, 15 };
            static readonly Random random = new Random();
            
            static bool generateAndCheckCandidate(int X) {
                var prefixCandidates = prefix.OrderBy(x => random.Next(0, prefix.Length)).Take(random.Next(1, 4)).ToList();
                var suffixCandidates = suffix.OrderBy(x => random.Next(0, suffix.Length)).Take(random.Next(1, 4)).ToList();
                if (prefixCandidates.Sum() + suffixCandidates.Sum() == X) {
                    Console.WriteLine(X + " = "  + String.Join("+", prefixCandidates) + "+" + String.Join("+", suffixCandidates));
                    return true;
                }
                return false;
            }
    
            static void Main(string[] args) {
                int maxAttempts = 10000;
                while (maxAttempts > 0 && !generateAndCheckCandidate(42))
                {
                    --maxAttempts;
                }
            }
        }
    }
    // Output:
    // 42 = 8+15+0+0+7+12+0
