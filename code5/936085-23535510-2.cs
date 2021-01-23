    var apiResponse = new ApiResponse() { api_name = "test api" };
                var stringwriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringwriter))
                {
                    var ser = new System.Xml.Serialization.XmlSerializer(
                        typeof(ApiResponse));
                    ser.Serialize(writer,apiResponse);
                }
                var xmlString= stringwriter.GetStringBuilder().ToString();
