    string datos = "";
        string url = "http://server.com/wsDirectory/wsFile.asmx/MethodName?param1=value1&param2=value2";
        string respuesta = "";
        try
        {
            byte[] buffer = Encoding.ASCII.GetBytes(datos);
            System.Net.HttpWebRequest solicitud = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            solicitud.Method = "GET";
            solicitud.ContentLength = buffer.Length;
            System.Net.HttpWebResponse r = (System.Net.HttpWebResponse)solicitud.GetResponse();
            System.IO.Stream datosRespuesta = r.GetResponseStream();
            System.IO.StreamReader lector = new System.IO.StreamReader(datosRespuesta);
            respuesta = lector.ReadToEnd();
            System.Web.Script.Serialization.JavaScriptSerializer serializador = new System.Web.Script.Serialization.JavaScriptSerializer();
            Dictionary<string, object> resultado = (Dictionary<string, object>)serializador.Deserialize<object>(respuesta);
            Console.Write("Resultado obtenido: " + resultado.ToString());
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
        Console.ReadLine();
