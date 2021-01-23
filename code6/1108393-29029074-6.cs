    public class SentModel
    {
        public string Input1 { get; set; }
        public string Intput2 { get; set; }
    }
    [HttpPost]
    public void TestMethod(SendModel model)
    {
        model.Input1.ToString();
    }
