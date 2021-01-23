    using System;
    using System.Diagnostics;
    using Microsoft.Practices.Unity;
    
    namespace SO29233419
    {
        public interface IDependency { }
        public interface ISpecializedDependencyForB : IDependency { }
        public interface ISpecializedDependencyForC : IDependency { }
    
        public class ConcreteDependencyForB : ISpecializedDependencyForB {};
        public class ConcreteDependencyForC : ISpecializedDependencyForC { };
    
        public abstract class TypeA
        {
            // Your polymorphic method
            public abstract void AbtractMethod();
            // Only exposing this for the purpose of demonstration
            public abstract IDependency Dependency { get; }
        }
        public class TypeB : TypeA
        {
            private readonly ISpecializedDependencyForB _dependency;
            public TypeB(ISpecializedDependencyForB dependency)
            {
                _dependency = dependency;
            }
            public override void AbtractMethod()
            {
               // Do stuff with ISpecializedDependencyForB without leaking the dependency to the caller
            }
            // You hopefully won't need this prop
            public override IDependency Dependency
            {
                get { return _dependency; }
            }
        }
    
        public class TypeC : TypeA
        {
            private readonly ISpecializedDependencyForC _dependency;
            public TypeC(ISpecializedDependencyForC dependency)
            {
                _dependency = dependency;
            }
            public override void AbtractMethod()
            {
               // Do stuff with ISpecializedDependencyForC without leaking the dependency to the caller
            }
            public override IDependency Dependency
            {
                get { return _dependency; }
            }
        }
    
        public interface ITypeAFactory
        {
            TypeA CreateInstance(Type typeOfA);
        }
        public class ConcreteTypeAFactory : ITypeAFactory
        {
            private readonly IUnityContainer _container;
            public ConcreteTypeAFactory(IUnityContainer container)
            {
                _container = container;
            }
            public TypeA CreateInstance(Type typeOfA)
            {
                return _container.Resolve(typeOfA) as TypeA;
            }
        }
    
        public class TypeARepository
        {
            private readonly ITypeAFactory _factory;
            public TypeARepository(ITypeAFactory factory)
            {
                _factory = factory;
            }
            public TypeA GetById(int id)
            {
                // As per Ewan, some kind of Strategy Pattern.
                // e.g. fetching a record from a database and use a discriminating column etc.
                return (id%2 == 0)
                    ? _factory.CreateInstance(typeof (TypeB))
                    : _factory.CreateInstance(typeof (TypeC));
                // Set the properties of the TypeA from the database after creation?
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                // Unity Bootstrapping
                var myContainer = new UnityContainer();
                myContainer.RegisterType<ISpecializedDependencyForB, ConcreteDependencyForB>();
                myContainer.RegisterType<ISpecializedDependencyForC, ConcreteDependencyForC>();
                myContainer.RegisterType(typeof(TypeB));
                myContainer.RegisterType(typeof(TypeC));
                var factory = new ConcreteTypeAFactory(myContainer);
                myContainer.RegisterInstance(factory);
                myContainer.RegisterType<TypeARepository>(new InjectionFactory(c => new TypeARepository(factory)));
                // And finally, your client code.
                // Obviously your actual client would use Dependency Injection, not Service Location
                var repository = myContainer.Resolve<TypeARepository>();
    
                var evenNumberIsB = repository.GetById(100);
                Debug.Assert(evenNumberIsB is TypeB);
                Debug.Assert(evenNumberIsB.Dependency is ISpecializedDependencyForB);
    
                var oddNumberIsC = repository.GetById(101);
                Debug.Assert(oddNumberIsC is TypeC);
                Debug.Assert(oddNumberIsC.Dependency is ISpecializedDependencyForC);
            }
        }
    }
