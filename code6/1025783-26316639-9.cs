    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System;
    
    // A super-cheap immutable set of integers from 0 to 31 ; 
    // just a convenient wrapper around bit operations on an int.
    internal struct BitSet : IEnumerable<int>
    {
      public static BitSet Empty { get { return default(BitSet); } }
      private readonly int bits;
      private BitSet(int bits) { this.bits = bits; }
      public bool Contains(int item) 
      {
        Debug.Assert(0 <= item && item <= 31); 
        return (bits & (1 << item)) != 0; 
      }
      public BitSet Add(int item) 
      { 
        Debug.Assert(0 <= item && item <= 31); 
        return new BitSet(this.bits | (1 << item)); 
      }
      public BitSet Remove(int item) 
      { 
        Debug.Assert(0 <= item && item <= 31); 
        return new BitSet(this.bits & ~(1 << item)); 
      }
      IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
      public IEnumerator<int> GetEnumerator()
      {
        for(int item = 0; item < 32; ++item)
          if (this.Contains(item))
            yield return item;
      }
      public override string ToString() 
      {
        return string.Join(",", this);
      }
    }
