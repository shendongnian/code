    public string getCourseSchedule()
    {
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "apoplication/json";
            var url = "http://192.168.1.198:15014/ShoppingCart2/CourseSchedule";
            var json = new JavaScriptSerializer().Serialize(new
            {
                States = new[] { new { State = "MX" } },
                Zip = "",
                Miles = "",
                PaginationStart = 1,
                PaginationLimit = 3
            });
            byte[] data = Encoding.UTF8.GetBytes(json);
            byte[] result = client.UploadData(url, data);
            return Encoding.UTF8.GetString(result);
        }
    }
