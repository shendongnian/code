            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bfmt = new BinaryFormatter()
                {
                    SurrogateSelector = new NonSerializableSurrogateSelector(),
                    Binder = new IgnoreUnknownTypesBinder()
                };
                dict1 = (Dictionary<string, object>)bfmt.Deserialize(fs);
                dict2 = (Dictionary<string, string>)bfmt.Deserialize(fs);
            }
