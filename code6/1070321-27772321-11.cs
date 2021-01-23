        [WebMethod]
        public static string SayHello(List<string> names)
        {
            var str = "hello ";
            for (var i=0; i<names.Count; i++)            
            {
                str += (names[i] + ", ");
            }
            return str;
        }
