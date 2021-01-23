    public abstract class ParentClass<T> where T : Parent
    {
        protected virtual void BuildQueries()
        {
            var Engine = new FileHelperEngine<T>();
            var r = Engine.ReadFile(ResumeName);
        }
        protected T TopType { get; set; }
        // (...)
    }
    public class ChildClass : ParentClass<Child>
    {
        // don't need to override anything, because your property is generic now
        // which means it will be of type `Child` for this class
    }
    public class FileHelperEngine<T>
        where T : Parent  // this generic constraint might not be necessary
    {
        public T[] ReadFile(string name)
        {
        }
    }
