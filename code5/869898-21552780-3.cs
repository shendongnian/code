     MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(Your json string));
     DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(RootObject));
    RootObject parsedData= dataContractJsonSerializer.ReadObject(memoryStream) as RootObject;
    if(parsedData!=null)
    {
    MessageBox.Show(parsedData.SpData.results.First().ndetails.First().url.ToString());
    }
