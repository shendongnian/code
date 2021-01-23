    public IEnumerable<Boolean> Combine<Ta, Tb>(List<Ta> seqA, List<Tb> seqB)
    {
      if (seqA.Count != seqB.Count)
        throw new ArgumentException("Lists must be the same size...");
    
      for (int i = 0; i < seqA.Count; i++)
        yield return seqA[i].Equals(seqB[i]));
    }
