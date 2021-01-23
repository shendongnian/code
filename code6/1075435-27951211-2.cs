            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new LimitedConverter() });
                var json = serializer.Serialize(new Limited());
                Debug.WriteLine(json);
                var status = serializer.Deserialize<Limited>(json);
                var json2 = serializer.Serialize(status);
                Debug.WriteLine(json2);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString()); // NO ASSERT.
            }
