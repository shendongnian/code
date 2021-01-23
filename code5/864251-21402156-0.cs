    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Test
    {
        public interface IStep
        {
            IContext Execute(IContext context);
        }
        // Make a generic version also
        public interface IStep<T> : IStep where T : IContext
        {
            T Execute(T context);
        }
        public class Assemblyline
        {
            private readonly List<IStep> _steps;
            public Assemblyline(List<IStep> steps)
            {
                _steps = steps;
            }
            public void Execute(IContext context)
            {
                foreach (var step in _steps)
                {
                    step.Execute(context);
                }
            }
        }
        public interface IContext
        {
            string Id { get; set; }
        }
        public interface IAbcContext : IContext
        {
            string Abc { get; set; }
        }
        public interface IDefContext : IContext
        {
            string Def { get; set; }
        }
        public class XyzContext : IAbcContext, IDefContext
        {
            public string Id { get; set; }
            public string Abc { get; set; }
            public string Def { get; set; }
        }
        // This will do the casting for you
        public abstract class BaseStep<T> : IStep<T> where T : IContext
        {
            public abstract T Execute(T context);
            public IContext Execute(IContext context)
            {
                return (IContext)Execute((T)context);
            }
        }
        // Now less code for you:
        public class AbcStep : BaseStep<IAbcContext>
        {
            public override IAbcContext Execute(IAbcContext context)
            {
                var abcContext = context;
                abcContext.Abc = "some value for Abc";
                return abcContext;
            }
            public string Id { get; set; }
        }
        public class DefStep : BaseStep<IDefContext>
        {
            public override IDefContext Execute(IDefContext context)
            {
                var defContext = context;
                defContext.Def = "some value for Def";
                return defContext;
            }
            public string Id
            {
                get;
                set;
            }
        }
        internal class Program
        {
            private static void Main()
            {
                var steps = new List<IStep>();
                steps.Add(new AbcStep());
                steps.Add(new DefStep());
                var assemblyline = new Assemblyline(steps);
                var context = new XyzContext { Id = "1", Abc = "blabla", Def = "other value" };
                assemblyline.Execute(context);
            }
        }
    }
