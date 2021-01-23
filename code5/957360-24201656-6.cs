    List<Claimant> list = from ...
                          where ...
                          select ...
    foreach (Claimant claimant in list)
    {
        claimant.NormalizeTaxNumber();
    }
    public class Claimant
    {
        // ...
        public void NormalizeTaxNumber()
        {
            if (String.IsNullOrEmpty(TaxNumber))
            { TaxNumber = "0"; }
        }
    }
