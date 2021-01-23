    public abstract class ScriptFunction
    {
         public abstract string Name { get; }
         public abstract int ParameterCount { get; }
         public abstract object Execute(params object[] parameters);
    }
