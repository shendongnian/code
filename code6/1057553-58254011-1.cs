            var ser = new SerializeMe();
            ser.VisualData.Data = (int)1;
            var serializationResult = JsonConvert.SerializeObject(ser);
            var deserializedObject = JsonConvert.DeserializeObject<SerializeMe>(serializationResult);
            ser.VisualData.Data = new System.Drawing.Rectangle(0, 1, 2, 3);
            serializationResult = JsonConvert.SerializeObject(ser);
            deserializedObject = JsonConvert.DeserializeObject<SerializeMe>(serializationResult);
