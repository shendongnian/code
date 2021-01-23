    void Main()
    {
        Process(new DifferentialAnnuityContext());
        Process(new EqualAnnuityContext());
    }
    
    public static void Process(AnnuityContext context)
    {
        context.Calculate();
    }
    
    public abstract class AnnuityContext
    {
        public abstract void Calculate();
    }
    
    public class DifferentialAnnuityContext : AnnuityContext
    {
        public override void Calculate()
        {
            Debug.WriteLine("Differential");
        }
    }
    
    public class EqualAnnuityContext : AnnuityContext
    {
        public override void Calculate()
        {
            Debug.WriteLine("Equal");
        }
    }
