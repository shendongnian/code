    using System;
    using System.IdentityModel.Tokens;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    
    namespace MyDevWebApiService.Common
    {
        public class AzureADAuthorizationHandler : DelegatingHandler //: AuthorizeAttribute
        {
             //public override void OnAuthorization(HttpActionContext actionContext)
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestObject, CancellationToken cancellationToken)
            {
                HttpResponseMessage httpResponseMessage = null;
    
                try
                {
                    var RequuestObj = System.Web.HttpContext.Current.Request;
                    var AuthHeader = RequuestObj.Headers["Authorization"];
    
                    if (AuthHeader == null)
                    {
                        httpResponseMessage = httpRequestObject.CreateErrorResponse(HttpStatusCode.BadRequest, "No authorization header present in the request");
                    }
                    else
                    {
                        string encodedTokenString = AuthHeader.StartsWith("Bearer ") ? AuthHeader.Substring(7) : AuthHeader;
                        //Validate date the token - Work in Progress. Should be able to handle Bearer and Basic headers.
                        //Extract the Azure Ad info (tenant, client id and client security key etc) and use ADAL to authenticate with Azure AD.
                        SetCurrentPrincipal(encodedTokenString);
                    }
                }            
                catch (Exception ex)
                {
                    httpResponseMessage = httpRequestObject.CreateErrorResponse(HttpStatusCode.BadRequest, ex + "Invalid header, header token extration failed");
                }
                
                return httpResponseMessage != null ? Task.FromResult(httpResponseMessage) : base.SendAsync(httpRequestObject, cancellationToken);
            }
    
            public void SetCurrentPrincipal(string encodedTokenString)
            {
                try
                {
                    ClaimsIdentity ClaimsIdentityObject = new ClaimsIdentity();
    
                    JwtSecurityToken JwtSecurityTokenObject = new System.IdentityModel.Tokens.JwtSecurityToken(encodedTokenString);
    
                    foreach (Claim ClaimObj in JwtSecurityTokenObject.Claims)
                    {
                        ClaimsIdentityObject.AddClaim(ClaimObj);
                    }
    
                    Thread.CurrentPrincipal = new ClaimsPrincipal(ClaimsIdentityObject);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
