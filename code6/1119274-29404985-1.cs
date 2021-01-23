    internal abstract class ReadonlyCoefs
    {
        public abstract Boolean IsCoefAllowed();
    }
    
    internal class Coefs : ReadonlyCoefs
    {
        public override Boolean IsCoefAllowed()  { ... }
        public void SetIsCoefAllowed()  { ... }
    }
