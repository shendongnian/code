    public sealed class XCommand
    {
        IHaveARunMethod runClass;
        public XCommand(IHaveARunMethod classWithRunMethod)
        {
            runClass = classWithRunMethod;
        }
        public IResult Author()
        {
            //DO SOMETHING AND RETURN BASE.
            return runClass.run();
        }        
    }
    public interface IHaveARunMethod
    {
        IResult Run();
    }
    public class HasRunMethod : IHaveARunMethod
    {
        public IResult Run()
        {
            //Your run code here.
        }
    }
