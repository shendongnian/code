            dynamic state = new JObject();
            state.Add("Date", DateTime.Now);  
            state.Sections = new JArray() as dynamic;  
            var _strDJSON = JsonConvert.SerializeObject(state);
            var _strDDeserialize = JsonConvert.DeserializeObject<dynamic>(_strDJSON);  
