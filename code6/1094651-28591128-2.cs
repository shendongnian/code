    public class MyVoidConverter : IActionResultConverter
    {
        public HttpResponseMessage Convert(HttpControllerContext controllerContext, object actionResult)
        {
            var res = controllerContext.Request.CreateResponse(HttpStatusCode.OK);
            res.Content = new StringContent("void response");
            return res;
        }
    }
