    public IHttpActionResult GetStuff()
    {
        return Ok( new {
            AnswerGridCorrect = answerGridCorrect,
            Result = result,
            UpdateRowCount = updateRowCount
        } );
    }
