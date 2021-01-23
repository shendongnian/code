     [TestFixture]
    public class DMSTransferWebRequestTest
    {
        [Test]
        public void TestPostResquest()
        {      
            string expected = "Content";
            //Prepare the Mocked Response Stream
            byte [] expectedBytes = Encoding.UTF8.GetBytes(expected);
            Stream responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);
            //Prepare the Mocked Request Stream
            Stream requestStream = new MemoryStream();
            requestStream.Write(expectedBytes, 0, expectedBytes.Length);
            requestStream.Seek(0, SeekOrigin.Begin);
            //Mock the HttpWebResponse
            Mock<HttpWebResponse> response = new Mock<HttpWebResponse>();
            //Set the method GetResponseStream to return the Response Stream mocked
            response.Setup(c => c.GetResponseStream()).Returns(responseStream);
            response.Setup(c => c.StatusCode).Returns(HttpStatusCode.OK);
            //Set the method GetRequestStream to return the Request Stream mocked
            Mock<HttpWebRequest> request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponse()).Returns(response.Object);
            request.Setup(c => c.GetRequestStream()).Returns(requestStream);
            //Create a Object to mock the HttpWebRequest Create Method
            Mock<IHttpWebRequestFactory> factory = new Mock<IHttpWebRequestFactory>();
            factory.Setup(c => c.Create(It.IsAny<string>()))
                .Returns(request.Object);
            TestableRestClient client = new TestableRestClient();
            client.HttpWebRequestFake = factory.Object.Create("http://mytest");
            long actualBytes = client.PostRequest(new Uri("http://mytest"), expected);
            string actual = client.responseValue;
            
            Assert.AreEqual(expected, actual);
           
        }
    }
