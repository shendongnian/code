    var str = await resp.Content.ReadAsStringAsync();
    var jsonObj = JsonConvert.DeserializeObject<Response>(str);
---
    public class D
    {
        public string __type { get; set; }
        public bool Success { get; set; }
    }
    public class Response
    {
        public D d { get; set; }
    }
