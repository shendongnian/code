        ArrayList arrayList = new ArrayList();
        arrayList.Add(1);
        arrayList.Add(2);
        arrayList.Add(3);
        Newtonsoft.Json.JsonSerializer jsr = new Newtonsoft.Json.JsonSerializer();
        System.IO.StringWriter sw=new System.IO.StringWriter();
        Newtonsoft.Json.JsonTextWriter jtw = new Newtonsoft.Json.JsonTextWriter(sw);
        jsr.Serialize(jtw, arrayList);
        string jsArrayJSON = sw.ToString();
