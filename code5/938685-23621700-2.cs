    // Assembly Microsoft.AspNet.Identity.Core.dll, v2.0.0.0
    namespace Microsoft.AspNet.Identity
    {
      public class RoleManager<TRole> : RoleManager<TRole, string> 
        where TRole : class, Microsoft.AspNet.Identity.IRole<string>
      {
        // Summary:
        //     Constructor
        //
        // Parameters:
        //   store:
        public RoleManager(IRoleStore<TRole, string> store);
      }
    }
