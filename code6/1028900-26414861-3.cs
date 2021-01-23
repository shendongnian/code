        public static void TestJsonParse(string json)
        {
            try
            {
                var _mapping = JObject.Parse(json);
                var _json = _mapping.ToString();
                // _json == json at this poing other than some formating
                var map = _mapping["c1-14.10.16"]["mappings"]["applog"]["properties"];
                map.WritePropertiesToConsole();
                Debug.Assert(map.Count() == 1); // No assert because the properties aren't here.
                var subMap = _mapping["c1-14.10.16"]["mappings"]["applog"]["properties"]["error"]["properties"]["error"]["properties"]["data"]["properties"];
                subMap.WritePropertiesToConsole();
                Debug.Assert(subMap.Count() == 8); // no assert - the properties are all here.
                Debug.Assert(_mapping["c1-14.10.16"]["mappings"]["applog"]["properties"]["error"]["properties"]["error"]["properties"]["data"]["properties"]["Microsoft.ServiceBus"]["index_analyzer"].ToString() == "standard"); // no assert
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());  // No exception, no assert.
            }
        }
        public static void WritePropertiesToConsole(this JToken subMap)
        {
            int iToken = 0;
            Console.WriteLine(string.Format("Tokens for {0}: {1} found", subMap.Path, subMap.Count()));
            foreach (JToken v in subMap)
            {
                string s = v.ToString();
                Console.WriteLine(string.Format("Token {0}: {1}", iToken++, s));
            }
        }
