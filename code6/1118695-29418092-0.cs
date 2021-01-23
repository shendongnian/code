    [HttpPost]
    public async Task<HttpResponseMessage> saveFiles()
    {
        if (HttpContext.Current.Request.Files.AllKeys.Any())
        {
            ...
            string[] tags = sTags.Split(new char[] { ',' });
            await GetSpeechActionsCalculated(voiceoverWavPath, tags, voiceoverInfo.Duration);
            // now return the times to the client
            var finalTimes = GetFinalTimes(HttpContext.Current.Server.MapPath("~/files/low/"), task.Result.timeTags);
            var goodResponse = Request.CreateResponse(HttpStatusCode.OK, finalTimes);
            return goodResponse;
        }
        return Request.CreateResponse(HttpStatusCode.OK, "no files");
    }
