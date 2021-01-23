    [Route("/api/whatever", "GET")]
    public class ListWhateverRequest : IReturn<List<Whatever>>
    {
        public string WhateverId { get; set; }
    }
    // Action
    public List<Whatever> Get(ListWhateverRequest request)
    {
        ...
    }
    [Route("/api/whatever", "POST,PUT,DELETE")]
    public class UpdateWhateverRequest : IReturn<bool>
    {
        public string WhateverId { get; set; }
    }
    // Action
    public bool Post(UpdateWhateverRequest request)
    {
        ...
    }
    public bool Put(UpdateWhateverRequest request)
    {
        ...
    }
    public bool Delete(UpdateWhateverRequest request)
    {
        ...
    }
