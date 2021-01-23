    public class WebService1 : System.Web.Services.WebService
{
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string HelloWorld(string param2)
    {
        Service1 service1 = new Service1();
        Person person = service1.HelloWorld(param2);
        return person.name;
    }
