                var apiResponse = new ApiResponse() { api_name = "test api" };
                using (var writer = XmlWriter.Create(@"apiData.xml"))
                {
                    var ser = new System.Xml.Serialization.XmlSerializer(
                        typeof(ApiResponse), new XmlRootAttribute("newRoot"));
                    ser.Serialize(writer,apiResponse);
                }
