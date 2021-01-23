      Task<int> tasks;
      for (int i = 0; i < 10; i++)
      {
        tasks = Task.Run<int>(() =>
          {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pages[i]);
            int code = 0;
            try
            {
              WebResponse response = request.GetResponse();
              HttpWebResponse r = (HttpWebResponse)response;
              code = (int)r.StatusCode;
            }
            catch (WebException we)
            {
              var r = ((HttpWebResponse)we.Response).StatusCode;
              code = (int)r;
            }
            return code;
          }
        );
      }
      await tasks;
