    namespace Microsoft.AspNet.Identity
    {
      /// <summary>
      /// Used to validate an item
      /// 
      /// </summary>
      /// <typeparam name="T"/>
      public interface IIdentityValidator<in T>
      {
        /// <summary>
        /// Validate the item
        /// 
        /// </summary>
        /// <param name="item"/>
        /// <returns/>
        Task<IdentityResult> ValidateAsync(T item);
      }
    }
