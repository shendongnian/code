      MemoryStream stream1 = new MemoryStream();
      DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
      settings.EmitTypeInformation = System.Runtime.Serialization.EmitTypeInformation.Never;
      DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Employee>), settings);
      ser.WriteObject(stream1, esc.Listing("s"));
      stream1.Position = 0;
      StreamReader sr = new StreamReader(stream1);
      dvJson.InnerHtml = sr.ReadToEnd();
