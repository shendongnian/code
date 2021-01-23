    class Ticker {
       Dictionary<string, int> dict = ..;
       // I don't actually know what contract you need
       public Decay(string symbol, int value) {
          // Handle all logic uniformly here such as checking to make sure it can't
          // go negative.
       }
    }
