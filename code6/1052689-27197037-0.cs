    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;
 
    public class SomeClass
    {
        // This is the one I want to be the default by selecting it.
        public SomeClass(string arg1, AnArgClass arg2) { }
        // This is default if I don't purposely select it.
        public SomeClass(string arg1, string arg2, string arg3) { }
    }
    public class AnArgClass { }
    public class SampleRegistry : Registry
    {
        public SampleRegistry()
        {
            var selectors = new SelectorsList();
            Policies.ConstructorSelector(selectors);
            For<SomeClass>().Use<SomeClass>();
            selectors.Add<SomeClass>(new SelectorByTypes(new[] { typeof(string), typeof(AnArgClass) }));
        }
    }
    
    public class SelectorByTypes : IConstructorSelector
    {
        private Type[] mArgumentsTypes;
        public SelectorByTypes(IEnumerable<Type> argumentsTypes)
        {
            mArgumentsTypes = argumentsTypes.ToArray();
        }
        public ConstructorInfo Find(Type pluggedType)
        {
            return pluggedType.GetConstructor(mArgumentsTypes); // GetConstructor() ext in SM.TypeRules
        }
    }
    public class SelectorsList : IConstructorSelector
    {
        // Holds the selectors by type
        private Dictionary<Type, IConstructorSelector> mTypeSelectors = new Dictionary<Type, IConstructorSelector>();
        // The usual default, from SM.Pipeline
        private GreediestConstructorSelector mDefaultSelector = new GreediestConstructorSelector(); 
        public void Add<T>(IConstructorSelector selector)
        {
            mTypeSelectors.Add(typeof(T), selector);
        }
        public ConstructorInfo Find(Type pluggedType)
        {
            ConstructorInfo selected = null;
            if (mTypeSelectors.ContainsKey(pluggedType))
            {
                var selector = mTypeSelectors[pluggedType];
                selected = selector.Find(pluggedType);
            }
            else
            {
                selected = mDefaultSelector.Find(pluggedType);
            }
            return selected;
        }
    }
