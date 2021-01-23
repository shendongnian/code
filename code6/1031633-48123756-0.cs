    namespace WeBAPITest
    {
    #region Using Statements:
    using System.Net.Http;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    #endregion
    public class HttpWebApi
    {
    #region Fields:
    private static readonly HttpClient client = new HttpClient();
    #endregion
    #region Properties:
    /// <summary>
    /// The basr Uri.
    /// </summary>
    public string BaseUrl { get; set; }
    /// <summary>
    /// Username.
    /// </summary>
    protected internal string Username { get; set; }
    /// <summary>
    /// Password.
    /// </summary>
    protected internal string Password { get; set; }
    /// <summary>
    /// The instance of the Root Object Json Deserialised Class.
    /// </summary>
    internal Rootobject Authentication { get; set; }
    /// <summary>
    /// The Access Token from the Json Deserialised Login.
    /// </summary>
    public string AccessToken { get { return Authentication.access_token; } }
    #endregion
    public HttpWebApi(string baseurl)
    {
        // Init Base Url:
        BaseUrl = baseurl;
    }
    /// <summary>
    /// Get from the Web API.
    /// </summary>
    /// <param name="path">The BaseUrl + path (Uri.Host + api/Controller) to the Web API.</param>
    /// <returns>A Task, when awaited, a string</returns>
    public async System.Threading.Tasks.Task<string> Get(string path)
    {
        if (Authentication.access_token == null)
        throw new System.Exception("Authentication is not completed.");
        // GET
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Authentication.access_token);
        return await client.GetStringAsync(BaseUrl + path);
    }
    /// <summary>
    /// Logs In and populates the Authentication Variables.
    /// </summary>
    /// <param name="username">Your Username</param>
    /// <param name="password">Your Password</param>
    /// <returns>A Task, when awaited, a string</returns>
    public async System.Threading.Tasks.Task<string> Login(string username, string password)
    {
        // Set Username:
        Username = username;
        // Set Password:
        Password = password;
        // Conf String to Post:
        var Dic = new Dictionary<string, string>() { { "grant_type", "password" }, { "username", "" }, { "password", "" } };
        Dic["username"] = username;
        Dic["password"] = password;
        // Post to Controller:
        string auth = await Post("/Token", Dic);
        // Deserialise Response:
        Authentication = JsonConvert.DeserializeObject<Rootobject>(auth);
        return auth;
    }
    /// <summary>
    /// Post to the Web API.
    /// </summary>
    /// <param name="path">The BaseUrl + path (Uri.Host + api/Controller) to the Web API.</param>
    /// <param name="values">The new Dictionary<string, string> { { "value1", "x" }, { "value2", "y" } }</param>
    /// <returns>A Task, when awaited, a string</returns>
    public async System.Threading.Tasks.Task<string> Post(string path, Dictionary<string, string> values)
    {
        // Add Access Token to the Headder:
        if (Authentication != null)
        if (Authentication.access_token != "")
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Authentication.access_token);
        // Encode Values:
        var content = new FormUrlEncodedContent(values);
        // Post and get Response:
        var response = await client.PostAsync(BaseUrl + path, content);
        // Return Response:
        return await response.Content.ReadAsStringAsync();
    }
    /// <summary>
    /// Register a new User.
    /// </summary>
    /// <param name="username">Your Username, E-Mail</param>
    /// <param name="password">Your Password</param>
    /// <returns>A Task, when awaited, a string</returns>
    public async System.Threading.Tasks.Task<string> Register(string username, string password)
    {
        // Register: api/Account/Register
        var Dic = new Dictionary<string, string>() { { "Email", "" }, { "Password", "" }, { "ConfirmPassword", "" } };
        Dic["Email"] = username;
        Dic["Password"] = password;
        Dic["ConfirmPassword"] = password;
        return await Post("api/Account/Register", Dic);
    }
    }
    /// <summary>
    /// For Json Deserialisation.
    /// </summary>
    internal class Rootobject
    {
    /// <summary>
    /// The Web Api Access Token. Gets added to the Header in each communication.
    /// </summary>
    public string access_token { get; set; }
    /// <summary>
    /// The Token Type
    /// </summary>
    public string token_type { get; set; }
    /// <summary>
    /// Expiry.
    /// </summary>
    public int expires_in { get; set; }
    /// <summary>
    /// The Username.
    /// </summary>
    public string userName { get; set; }
    /// <summary>
    /// Issued.
    /// </summary>
    public string issued { get; set; }
    /// <summary>
    /// Expiry.
    /// </summary>
    public string expires { get; set; }
    }
    }
