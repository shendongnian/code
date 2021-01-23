    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Web;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.DirectoryServices.AccountManagement;
    using System.Security;
    using System.Globalization;
    namespace SayHelloClassification
    {
    [WebService(Namespace = "http://localhost/Service1/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
        public class Service1 : System.Web.Services.WebService
    {
      [WebMethod(Description = "Call to change classification")]
      public string SayHello()
      {
        string currentUser = Environment.UserName;
        PrincipalContext context = new PrincipalContext(ContextType.Domain,     
        Environment.UserDomainName);
        GroupPrincipal group = GroupPrincipal.FindByIdentity(context, "YOURUSERSGROUP");
        UserPrincipal user = UserPrincipal.FindByIdentity(context, currentUser);
        if (!user.IsMemberOf(group))
        {
          throw new SecurityException("Access Denied: User has no permission to process the   
          request");
        }
        else
        {
		  // Authenticated
          // Your Code Goes here
        }
      }
	  }
