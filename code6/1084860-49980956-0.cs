    using System;
    using System.Reflection;
    
    public static class GetterSetterHelper
    {
        abstract class Factory<T, TValue>
        {
            public abstract Func<T, TValue> CreateGetter(MethodInfo method);
            public abstract Action<T, TValue> CreateSetter(MethodInfo method);
    
            public static Factory<T, TValue> Create(Type runtimeType)
            {
                var genericType = runtimeType.IsValueType ? typeof(StructFactory<,,>) : typeof(Factory<,,>);
                var factoryType = genericType.MakeGenericType(new Type[] { runtimeType, typeof(T), typeof(TValue) });
                return (Factory<T, TValue>)Activator.CreateInstance(factoryType);
            }
        }
    
        class Factory<TRuntime, T, TValue> : Factory<T, TValue>
            where TRuntime : class, T
        {
            public override Func<T, TValue> CreateGetter(MethodInfo method)
            {
                var d = (Func<TRuntime, TValue>)Delegate.CreateDelegate(typeof(Func<TRuntime, TValue>), method);
                return delegate (T target) { return d((TRuntime)target); };
            }
    
            public override Action<T, TValue> CreateSetter(MethodInfo method)
            {
                var d = (Action<TRuntime, TValue>)Delegate.CreateDelegate(typeof(Action<TRuntime, TValue>), method);
                return delegate (T target, TValue value) { d((TRuntime)target, value); };
            }
        }
    
        class StructFactory<TRuntime, T, TValue> : Factory<T, TValue>
            where TRuntime : struct, T
        {
            delegate TValue GetterDelegate(ref TRuntime instance);
    
            public override Func<T, TValue> CreateGetter(MethodInfo method)
            {
                var d = (GetterDelegate)Delegate.CreateDelegate(typeof(GetterDelegate), method);
                return delegate (T target)
                {
                    var inst = (TRuntime)target;
                    return d(ref inst);
                };
            }
    
            public override Action<T, TValue> CreateSetter(MethodInfo method)
            {
                // It makes little sense to create setter which sets value to COPY of value type
                // It would make sense if we use delegate like:
                // void ActionRef<T, TValue(ref T inst, TValue value);
                throw new NotSupportedException();
            }
        }
    
        public static Func<T, TValue> CreateGetter<T, TValue>(this MethodInfo methodInfo)
        {
            return Factory<T, TValue>.Create(methodInfo.ReflectedType).CreateGetter(methodInfo);
        }
    
        public static Action<T, TValue> CreateSetter<T, TValue>(this MethodInfo methodInfo)
        {
            return Factory<T, TValue>.Create(methodInfo.ReflectedType).CreateSetter(methodInfo);
        }
    }
