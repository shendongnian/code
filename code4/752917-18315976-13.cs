    public interface IEpl2GeneralFactoryProduct
    {
        string GetFactoryKey();
    }
    public interface IEpl2Command
    {
        string CommandString { get; set; }
    }
    public interface IDrawableCommand : IEpl2Command
    {
        void Paint(System.Drawing.Graphics g, System.Drawing.Image buffer);
    }
