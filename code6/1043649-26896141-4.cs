    public static class TestCFCConnectResponse
    {
        static CFCConnectResponse CreateTest()
        {
            return new CFCConnectResponse()
            {
                StatusCode = 101,
                StatusDescription = "here is a description",
                Comments = new CommentList("XMLErrMessage1", "XMLErrMessage2", "XMLErrMessage3"),
            };
        }
        public static void Test()
        {
            var response = CreateTest();
            try
            {
                var xml = DataContractSerializerHelper.GetXml(response);
                Debug.Write(xml);
                var newResponse = DataContractSerializerHelper.GetObject<CFCConnectResponse>(xml);
                Debug.Assert(newResponse != null);
                Debug.Assert(response.StatusCode == newResponse.StatusCode);
                Debug.Assert(response.StatusDescription == newResponse.StatusDescription);
                Debug.Assert(newResponse.Comments.SequenceEqual(response.Comments));
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
            }
        }
    }
