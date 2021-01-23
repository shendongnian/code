    public class NewChemicalFormula: ChemicalFormula
    {         
        public void Method()
        {
            Console.WriteLine("{0}", ChemicalFormula.GetType());       // Compile error
            Console.WriteLine("{0}", this.ChemicalFormula.GetType());  // Effectively same as above, compile error
            Console.WriteLine("{0}", ((IChemicalFormula)this).ChemicalFormula.GetType()); // Works, is that what you intend?
        }
    }
