            [WebMethod]
            [ System.Web.Script.Services.ScriptMethodAttribute()]
            //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Xml)]
            public static string [] GetList()
            {
                return bl.Context.Items.Select(i=>i.Name).ToArray();
            }
