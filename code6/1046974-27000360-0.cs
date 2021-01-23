    var jsonObj = await resp.Content.ReadAsJsonAsync<Response>();
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
