    public IEnumerable<string> AminoAcidToCodon(char aminoAcid)
    {
        for (int k = 0; k < AMINOS_PER_CODON.Length; k++)
        {
            if (AMINOS_PER_CODON[k] == aminoAcid)
            {
                yield return CODONS[k];
            }
        }
    }
    
    public IEnumerable<string> GetCodonsforPeptide(string pep)
    {
        if (string.IsNullOrEmpty(pep))
        {
            yield return string.Empty;
            yield break;
        }
            
        foreach (var codon in AminoAcidToCodon(pep[0]))
            foreach (var codonOfRest in GetCodonsforPeptide(pep.Substring(1)))
                yield return codon + codonOfRest;
    }
