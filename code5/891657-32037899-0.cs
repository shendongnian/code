    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace Tests
    {
    	static class ConvertTest
    	{
    		// conceptual point
    		static Func<TInput, TOutput> CreateConvertFunc<TInput, TOutput>()
    		{
    			var source = Expression.Parameter(typeof(TInput), "source");
    			// the next will throw if no conversion exists
    			var convert = Expression.Convert(source, typeof(TOutput));
    			var method = convert.Method;
    			if (method != null)
    			{
    				// here is your method info
    			}
    			else
    			{
    				// here is the case of primitive types
    				// unfortunately it would not help you, because it's resolved when you call Complile.
    				// but you can take a look at reference implementation how they handle it 
    			}
    			return Expression.Lambda<Func<TInput, TOutput>>(convert, source).Compile();
    		}
    		// cache
    		struct ConverterFunc<TInput, TOutput>
    		{
    			public static readonly Func<TInput, TOutput> Instance = CreateConvertFunc<TInput, TOutput>();
    		}
    		// fluent accessor
    		struct ConvertSource<T>
    		{
    			public T source;
    			public U To<U>()
    			{
    				try { return ConverterFunc<T, U>.Instance(source); }
    				catch (TypeInitializationException e) { throw e.InnerException; }
    			}
    		}
    		static ConvertSource<T> Convert<T>(this T source) { return new ConvertSource<T> { source = source }; }
    		// test
    		struct Wrapper<T>
    		{
    			public T Value;
    			public static implicit operator Wrapper<T>(T source) { return new Wrapper<T> { Value = source }; }
    			public static implicit operator T(Wrapper<T> source) { return source.Value; }
    		}
    		class A { }
    		class B : A { }
    		static void Main(string[] args)
    		{
    			var v0 = 1;
    			var v1 = v0.Convert().To<byte>();
    			var v2 = v1.Convert().To<double>();
    			var v3 = v2.Convert().To<decimal>();
    			var v4 = v3.Convert().To<Wrapper<decimal>>();
    			var v5 = v4.Convert().To<decimal?>();
    			var v6 = v5.Convert().To<int>();
    			var v7 = Enumerable.Empty<B>().Convert().To<IEnumerable<A>>();
    			var v8 = v7.Convert().To<int>(); // exception
    		}
    	}
    }
