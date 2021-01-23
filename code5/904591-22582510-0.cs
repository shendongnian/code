        public T DeserializeBinaryData<T>(byte[] serializedBinaryData)
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(serializedBinaryData, 0, serializedBinaryData.Length);
                memoryStream.Position = 0;
                if (compressed)
                {
                    using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        using (
                            var dictionaryReader = XmlDictionaryReader.CreateBinaryReader(gZipStream,
                                                                                          XmlDictionaryReaderQuotas
                                                                                              .Max))
                        {
                            var netDataContractSerializer = new NetDataContractSerializer();
                            var deserializedData = netDataContractSerializer.ReadObject(dictionaryReader);
                            return (T)deserializedData;
                        }
                    }
                }
                using (
                    var dictionaryReader = XmlDictionaryReader.CreateBinaryReader(memoryStream,
                                                                                  XmlDictionaryReaderQuotas
                                                                                      .Max))
                {
                    var deserializedData = new NetDataContractSerializer().ReadObject(dictionaryReader);
                    return (T)deserializedData;
                }
            }
        }
