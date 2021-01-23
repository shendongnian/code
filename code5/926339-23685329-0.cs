    using DotNetOpenAuth.OAuth;
    using DotNetOpenAuth.OAuth.ChannelElements;
    using DotNetOpenAuth.OAuth.Messages;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OpenId.Extensions.OAuth;
    
    // In my Page_Load method, I receive the GET request from NetSuite:
    public partial class sso_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    // This is what the NetSuite SuiteSignOn ConnectionPoint sends:
    // GET /administratorportal/SSO/sso_page.aspx?oauth_token=08046c1c166a7a6c47471857502d364b0d59415418156f15db22f76dcfe648&dc=001&env=SANDBOX
    // see the NetSuite SuiteSignOn doc about dc & env processing to build endpoints
    ServiceProviderDescription provider = GetServiceDescription();
    
    // Set up OAuth with our keys and stuff
    string token = Request.Params["oauth_token"];
    string consumerKey = "yourconsumerkey";    // this has to match what is defined on our NetSuite account - ConnectionPoint to CRMLink
    string sharedSecret = "yoursharedsecret";        // this has to match what is defined on our NetSuite account - ConnectionPoint to CRMLink - Careful - NO funny chars like '!'
    
    // I got this InMemoryTokenManager from another DotNetOpenAuth post in SO
    InMemoryTokenManager _tokenManager = new InMemoryTokenManager(consumerKey, sharedSecret);
    AuthorizationApprovedResponse authApprovedResponse = new AuthorizationApprovedResponse();
    authApprovedResponse.RequestToken = token;
    
    _tokenManager.StoreOpenIdAuthorizedRequestToken(consumerKey, authApprovedResponse);
    
    WebConsumer consumer = new WebConsumer(provider, _tokenManager);
    
    // this is the SSO address in netsuite to use.  Should be production or sandbox, based on the values of dc and env
    string uri = "https://system.sandbox.netsuite.com/app/common/integration/ssoapplistener.nl";
                    MessageReceivingEndpoint endpoint = new MessageReceivingEndpoint(uri, methods);
    
    WebRequest verifyRequest = consumer.PrepareAuthorizedRequest(endpoint, token );
    HttpWebResponse responseData = verifyRequest.GetResponse() as HttpWebResponse;
    
    XDocument responseXml;
    responseXml = XDocument.Load(responseData.GetResponseStream());
    
    // process the SSO values that come back from NetSuite in the XML  They should look something
    // like the following:
    /* XML response should look like this:
    
    <?xml version="1.0" encoding="UTF-8"?>
    <outboundSso>
        <entityInfo>
             <ENTITYINTERNALID>987654</ENTITYINTERNALID>
             <ENTITYNAME>Fred</ENTITYNAME>
             <ENTITYEMAIL>fred@yourcompany.com</ENTITYEMAIL>
        </entityInfo>
    </outboundSso>
    */
    
    // If that data looks good, you can mark the user as logged in, and redirect to whatever
    // page (like SSOLandingPage.aspx) you want, which will be shown inside a frame on the NetSuite page.
    
    Response.Redirect("~/SSOLandingPage.aspx", false);
    // If that data looks bad, invalid user/login?  Then you could respond with an error or redirect to a login.aspx page or something.
