    DataTable dt = (new tst()).Gettable();
                string s = string.Empty;
                s = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
               s= s.Replace("null", "\"\"");
                Object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
                return Ok(obj);
