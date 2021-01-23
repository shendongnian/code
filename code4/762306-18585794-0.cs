     using System;
     using System.Web;
     using System.Web.Services;
     using System.Web.Services.Protocols;
     using System.Configuration;
     [WebService(Namespace ="www.XMLWebServiceSoapHeaderAuth.net")
     ][WebServiceBinding(ConformsTo =WsiProfiles.BasicProfile1_1)]
     public class Service:System.Web.Services.WebService
      {
         public AuthSoapHd spAuthenticationHeader;
 
         public Service()
           {
           }
 
        public class AuthSoapHd: SoapHeader
        {
          public string strUserName;
          public string strPassword;
        }
 
          [WebMethod,SoapHeader("spAuthenticationHeader")]
        public string HelloWorld()
        {
         if (spAuthenticationHeader.strUserName =="TestUser" &&
           spAuthenticationHeader.strPassword =="TestPassword")
         {
           return "User Name : " +spAuthenticationHeader.strUserName + " and " +
           "Password : " +spAuthenticationHeader.strPassword;
         }
         else
         {
           return "Access Denied";
         }
      }
     }
