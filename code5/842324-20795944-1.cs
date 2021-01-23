    public void Serialize(Object obj, String FileFullPath)
            {
                byte[] serialized;
    
                using (var ms = new MemoryStream())
                {
                    Serializer.Serialize(ms, obj);
                    serialized = ms.ToArray();
                }
                File.WriteAllBytes(FileFullPath, serialized);
                
            }
