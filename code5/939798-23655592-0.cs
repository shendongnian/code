    List<Results> myResults = new List<Results>();
    //...
    public void BtnClick(...)
    {
        Results results = GetResultsForInput();
        myResults.Add(results);
    }
    //..
    //..
    public class Results
    {
       public int ID { get; set; }
       public string SomethingElse { get; set; } 
    }
