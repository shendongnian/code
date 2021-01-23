     namespace Foo.Controllers
    {
        [RoutePrefix("api/route")]
        public class SnoconesFooBarController : BaseApiController
        {
            /// <summary>
            /// Asks for a new foo to be created to the given subnet with the specific bar named
            /// </summary>
            /// <param name="fooData"></param>
            /// <returns></returns>
            [Route("newFoo/")]
            public async Task<IHttpActionResult> PostNewFooForSpecificBar(FooRequestObject fooData)
            {
            }
    }
