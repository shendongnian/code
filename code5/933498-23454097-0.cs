    private class Chemical
    {
        public string formula;
    }
    private class ChemDataAlcohol : Chemical
    {
        public string Name;
    }
    private class ChemDataAcidBase : Chemical
    {
        public decimal pH; // at 1.0 M
    }
    public static void Test()
    {
        Chemical[] chemicals = {
            new Chemical { formula = "H2O" },
            new ChemDataAcidBase { formula = "H2SO4", pH = 0 },
            new ChemDataAlcohol { formula = "C2H6O", Name="ethanol" },
            new Chemical { formula = "CO2" },
            new ChemDataAcidBase { formula = "CH3COOH", pH = 2.4M },
                                };
        List<ChemDataAlcohol> alcohols = chemicals.OfType<ChemDataAlcohol>().ToList();
        foreach (ChemDataAlcohol alcohol in alcohols) { string name = alcohol.Name; }
        List<ChemDataAcidBase> acids = chemicals.OfType<ChemDataAcidBase>().ToList();
        foreach (ChemDataAcidBase acid in acids) { decimal pH = acid.pH; }
    }
