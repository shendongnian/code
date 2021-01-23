    static bool findbits(BitArray bits, bool[] bitstofind)
      {
        IEnumerator e = bits.GetEnumerator();
        List<bool> bitsc = new List<bool>();
        while (e.MoveNext())
            bitsc.Add((bool)e.Current);
        for (int i = 0; i + bitstofind.Length < bitsc.Count; i++)
            if (bitsc.GetRange(i, bitstofind.Length).ToArray().SequenceEqual(bitstofind)) return true;
        return false;
      }
