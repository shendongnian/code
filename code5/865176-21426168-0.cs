    public static class ClientScriptManagerExtensions
        {
            /// <summary>
            /// Registers an object as a variable on the page
            /// </summary>
            public static void RegisterObjectAsVariable(this ClientScriptManager mgr, Type type, string variableName, object objectToEncode)
            {
                mgr.RegisterClientScriptBlock(type,
                    string.Concat("ClientScriptManagerExtensions_", variableName),
                    string.Concat("var ", variableName, " = ", new JavaScriptSerializer().Serialize(objectToEncode), ";"),
                    true);
            }
        }
