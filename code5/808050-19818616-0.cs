    public void UnpinBuild(int buildId, string comment = null)
    {
        var request = new RestRequest("builds/id:{id}/pin", Method.DELETE);
        request.AddUrlSegment("id", "" + buildId);
        if (!String.IsNullOrWhiteSpace(comment))
        {
            request.AddParameter("text/plain", comment, ParameterType.RequestBody);
        }
        Console.WriteLine("Executing '{0}' request to '{1}'...", request.Method, _restClient.BuildUri(request));
        var response = _restClient.Execute(request);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new Exception("Build does not exist for ID: " + buildId);
        }
        CheckForError(response);
        CheckForExpectedStatusCode(response, HttpStatusCode.NoContent);
    }
