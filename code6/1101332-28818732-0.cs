    // Server-Side
    public void VideosController : ApiController
    {
        [HttpGet]
        public void RegisterWatchedVideo(string id)
        {
            // do server side actions here.
        }
    }
    // Client Side
    $('#yourVideoElement').on('ended', function() {
        $.get('http://yourwebsitename.com/api/Videos?id=yourclientusername');
    });
