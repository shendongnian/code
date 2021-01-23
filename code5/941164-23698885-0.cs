    /api/libraries/2/books/10
    [HttpGet]
    [Route("api/libraries/{libraryid}/books/{bookid}")]
    public IHttpActionResult GetBookByLibraryIdAndBookId(int libraryId, int bookId)
    {
        // Code
    }
    /api/libraries/2/books/10/getHistory?startTime=20130101120000&endTime=20140101120000
    [HttpGet]
    [Route("api/libraries/{libraryid}/books/{bookid}/getHistory")]
    public IHttpActionResult GetHistoryByLibraryIdAndBookId(int libraryId, int bookId, [FromUri] DateTime startTime, [FromUri] DateTime endTime)
    {
        // Code
    }
