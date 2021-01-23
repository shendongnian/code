    var assembly = Assembly.GetExecutingAssembly();
    string resourceName = (string)HttpContext.GetGlobalResourceObject("Resource1", "MyTemplate");
    string mystring = "";
    mystring = resourceName;
    mystring = mystring.Replace("$$Member$$", name);
    mystring = mystring.Replace("$$Subject$$", TxtSubject.Text);
    return mystring;
