    using System;
    using System.Linq;
    namespace Test {
      class Program {
        static void Main(string[] args) {
          var random = new Random();
          int[] sequence = new int[9];
          do {
            for (var i = 0; i < sequence.Length; i++) {
              sequence[i] = random.Next();
            }
          } while (sequence.Distinct().Count() != sequence.Length);
        }
      }
    }
