    #region Assembly System.Core.dll, v4.0.0.0
    // C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Core.dll
    #endregion
    using System.Collections;
    using System.Collections.Generic;
    namespace System.Linq
    {
      // Summary:
      //     Represents a collection of objects that have a common key.
      //
      // Type parameters:
      //   TKey:
      //     The type of the key of the System.Linq.IGrouping<TKey,TElement>.This type
      //     parameter is covariant. That is, you can use either the type you specified
      //     or any type that is more derived. For more information about covariance and
      //     contravariance, see Covariance and Contravariance in Generics.
      //
      //   TElement:
      //     The type of the values in the System.Linq.IGrouping<TKey,TElement>.
      public interface IGrouping<out TKey, out TElement> : IEnumerable<TElement>, IEnumerable
      {
        // Summary:
        //     Gets the key of the System.Linq.IGrouping<TKey,TElement>.
        //
        // Returns:
 		//     The key of the System.Linq.IGrouping<TKey,TElement>.
	 	TKey Key { get; }
	  }
    }
