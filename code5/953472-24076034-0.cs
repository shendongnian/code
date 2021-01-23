    [Route("{UserId}/{Category}/books/{BookType}/{Page}")]
                [HttpGet]
                [RequestAuthorization]
                 public Response Get(([FromUri] BookbRequestModel book )
                {          
                    var books= this.contentService.GetUserItems(book.UserId,book.Category,book.BookType,book.Page)
                    return new Response() { Status = ApiStatusCode.Ok, Books = books};
                }
