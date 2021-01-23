    Using Route attribute
    
    [RoutePrefix("api/v2/my")]
    public class MyV2Controller 
    {
        [HttpPost]
        [Route("action1")]
        public Task<UserModel> Action1([FromBody] FirstModel firstModel)
        { }
    
        [HttpPost]
        [Route("action2")]
        public Task<UserModel> Action2([FromBody] SecondModel secondModel)
        { }
    }
