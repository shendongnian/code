    enum CoefPermission
    {
        Allowed,
        Disallowed,
    }
    internal abstract class ReadonlyCoefs
    {
        public abstract CoefPermission GetCoef();
    }
