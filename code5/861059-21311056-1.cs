    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DotNetOpenAuth.OpenId;
    using DotNetOpenAuth.OpenId.RelyingParty;
    using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
    using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
    public partial class _Default : System.Web.UI.Page 
    {
          
       protected void Page_Load(object sender, EventArgs e)
       {
       
           openIdAuth();
      
       }
       protected void openIdAuth()
      {
           OpenIdAjaxRelyingParty rp = new OpenIdAjaxRelyingParty();
           var response = rp.GetResponse();
            
           if (response != null)
           {
             switch (response.Status)
             {
                case AuthenticationStatus.Authenticated:
                    NotLoggedIn.Visible = false;
                    Session["GoogleIdentifier"] = response.ClaimedIdentifier.ToString();
                    var fetchResponse = response.GetExtension<FetchResponse>();
                    Session["FetchResponse"] = fetchResponse;
                    var response2 = Session["FetchResponse"] as FetchResponse;
                    string UserName = response2.GetAttributeValue(WellKnownAttributes.Name.First) ?? "Guest"; // with the OpenID Claimed Identifier as their username.
                    string UserEmail = response2.GetAttributeValue(WellKnownAttributes.Contact.Email) ?? "Guest";
                    Session["username"] = UserName;
                    Session["useremail"] = UserEmail;
                    Response.Redirect("Default2.aspx");
                    break;
                case AuthenticationStatus.Canceled:
                    lblAlertMsg.Text = "Cancelled.";
                    break;
                case AuthenticationStatus.Failed:
                    lblAlertMsg.Text = "Login Failed.";
                    break;
            }
        }
        var CommandArgument = "https://www.google.com/accounts/o8/id";
        string discoveryUri = CommandArgument.ToString();
        OpenIdRelyingParty openid = new OpenIdRelyingParty();
        var url = new UriBuilder(Request.Url) { Query = "" };
        var request = openid.CreateRequest(discoveryUri); // This is where you would add any OpenID extensions you wanted
        var fetchRequest = new FetchRequest(); // to fetch additional data fields from the OpenID Provider
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.Country);
        request.AddExtension(fetchRequest);
        request.RedirectToProvider();
       }
     }
