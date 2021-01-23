    [HttpPost]
    public string Submit()
    {
        var result = new { success = true, someOtherDate = "testing"};
        var json = JsonConvert.SerializeObject(result);
        return json;
    }
