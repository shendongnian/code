    [Route("")]
    public async Task<IHttpActionResult> PostView(Guid taskId, [FromBody]View view)
    {
        // ... Code here to save the view
        return Created(new Uri(Url.Link(ViewRouteName, new { taskId = taskId, id = view.Id })), view);
    }
