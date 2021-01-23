    MethodResponse<byte[]> response = null;
                using (System.IO.MemoryStream stream1 = new System.IO.MemoryStream(data))
                {
                    System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(MethodResponse<byte[]>));
                    stream1.Position = 0;
                    response = (MethodResponse<byte[]>)ser.ReadObject(stream1);
                }
                return response;
