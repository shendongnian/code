    public IEnumerable<string> GetCodonsforPeptide(string pep)
    {
        if (string.IsNullOrEmpty(pep))
        {
            yield return string.Empty;
            yield break;
        }
            
        foreach (var codon in lookup(pep[0]))
            foreach (var codonOfRest in GetCodonsforPeptide(pep.Substring(1)))
                yield return codon + codonOfRest;
    }
