    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
               
        List<AA> list = new List<AA>();
        list.Add(new AA { A = "a", B = "b", C = "c", D = "d", E = "e", F = "f" });
        list.Add(new AA { A = "a", B = "b", C = "c", D = "d", E = "e", F = "f" });
        list.Add(new AA { A = "a", B = "b", C = "c", D = "d", E = "e", F = "f" });
        list.Add(new AA { A = "a", B = "b", C = "c", D = "d", E = "e", F = "f" });
        list.Add(new AA { A = "a", B = "b", C = "c", D = "d", E = "e", F = "f" });
        list.Add(new AA { A = "a", B = "b", C = "c", D = "d", E = "e", F = "f" });
        list.Add(new AA { A = "a", B = "b", C = "c", D = "d", E = "e", F = "f" });
    
        JavaScriptSerializer jSearializer = new JavaScriptSerializer();
    
        var result = new  { data = list, recordsTotal = 8 };
    
        context.Response.Write(jSearializer.Serialize(result));
    
    }
