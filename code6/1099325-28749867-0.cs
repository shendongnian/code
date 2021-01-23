    var protectedFile=
    new ProtectedFile("C",new FileIdInfo(new FileSystemFileIdInformation(
                            1, new FileId128(2,3)),
                    4));
                DataContractSerializer d = new DataContractSerializer(protectedFile.GetType());
                var stream = new MemoryStream();
                d.WriteObject(stream, protectedFile);
                stream.Seek(0, SeekOrigin.Begin);
                var fileAfterSerialization = d.ReadObject(stream);
