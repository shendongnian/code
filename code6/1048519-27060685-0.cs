    await var z = request.BeginGetResponse((IAsyncResult ar) =>
      {
        var rq = (HttpWebRequest) ar.AsyncState;
        using (var resp = (HttpWebResponse) rq.EndGetResponse(ar))
        {
          var s = resp.GetResponseStream();
        }
      }, null);
