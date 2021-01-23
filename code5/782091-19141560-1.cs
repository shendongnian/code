    using System;
    using System.Data;
    /// <summary>
    /// Requires type parameter that implements interface IEnumerable.
    /// </summary>
    class Ruby<T> where T : IDisposable
    {
    }
    /// <summary>
    /// Requires type parameter that is a struct.
    /// </summary>
    class Python<T> where T : struct
    {
    }
    /// <summary>
    /// Requires type parameter that is a reference type with a constructor.
    /// </summary>
    class Perl<V> where V : class, new()
    {
    }
    class Program
    {
        static void Main()
        {
    	    // DataTable implements IDisposable so it can be used with Ruby.
            Ruby<DataTable> ruby = new Ruby<DataTable>();
	    // Int is a struct (ValueType) so it can be used with Python.
	    Python<int> python = new Python<int>();
	    // Program is a class with a parameterless constructor (implicit)
	    // ... so it can be used with Perl.
	    Perl<Program> perl = new Perl<Program>();
        }
    }
