    using System;
    using System.Collections.Generic;
    using System.Reflection.Emit;
    
    public static class EnumUtils
    {
        public static TEnum Merge<TEnum>(this IEnumerable<TEnum> values)
            where TEnum : struct
        {
            TEnum merged = default(TEnum);
            if (values != null)
            {
                var or = Operator<TEnum>.Or;
                foreach (var value in values)
                {
                    merged = or(merged, value);
                }
            }
            return (TEnum)(object)merged;
        }
        static class Operator<T>
        {
            public static readonly Func<T, T, T> Or;
    
            static Operator()
            {
                var dn = new DynamicMethod("or", typeof(T),
                    new[] { typeof(T), typeof(T) }, typeof(EnumUtils));
                var il = dn.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Or);
                il.Emit(OpCodes.Ret);
                Or = (Func<T, T, T>)dn.CreateDelegate(typeof(Func<T, T, T>));
            }
    
        }
    }
    static class Program {
    
        [Flags]
        public enum Foo
        {
            None = 0, A = 1,  B =2, C = 4
        }
        static unsafe void Main()
        {
            var merged = EnumUtils.Merge(new[] { Foo.A, Foo.C });
    
        }
    }
