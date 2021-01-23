            //using System;
            //using System.Collections.Generic;
            //using System.Linq;
            //using Newtonsoft.Json.Linq;
            string validJson = "[" + json + "]";
            JArray jsonArray = JArray.Parse(validJson);
            List<Tuple<string, string>> tupleJson = jsonArray
                .Select(p => new Tuple<string, string>((string)p["name"], (string)p["value"]))
                .ToList();
