    var continuation = httpResponseMessage.ContinueWith((task) =>
        {
            if (!task.IsFaulted)
            {
                HttpResponseMessage response = task.Result;
                return response.Content.ReadAsStringAsync().ContinueWith(
                (stringTask) =>
                {
                ...
