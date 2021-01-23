    string parameter1 = "";
    using (MemoryStream memoryStream = new MemoryStream())
    {
       DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Course));
     serializer.WriteObject(memoryStream, course);
     parameter1 = Encoding.Default.GetString(memoryStream.ToArray());
}
