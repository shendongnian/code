    void Main()
    {
    
    var list = new List<Test>();
    list.Add(new Test{ Machine="m1", Sample="s1", Experiment="e1",  DateCompleted = DateTime.Now.AddDays(-2)});
    list.Add(new Test{ Machine="m1", Sample="s1", Experiment="e1", DateCompleted = DateTime.Now.AddDays(-1)});
    list.Add(new Test{ Machine="m1", Sample="s1", Experiment="e1", DateCompleted = DateTime.Now});
    list.Add(new Test{ Machine="m2", Sample="s1", Experiment="e1",  DateCompleted = DateTime.Now.AddDays(-2)});
    list.Add(new Test{ Machine="m2", Sample="s1", Experiment="e1", DateCompleted = DateTime.Now.AddDays(-1)});
    list.Add(new Test{ Machine="m2", Sample="s1", Experiment="e1", DateCompleted = DateTime.Now.AddHours(-1)});
    
    var q = from s in list
    group s by new {s.Machine, s.Sample} 
    into gs
    select new {
    Machine = gs.Key.Machine,Sample = gs.Key.Sample
    ,DateCompleted = gs.OrderByDescending(f => f.DateCompleted).FirstOrDefault().DateCompleted
    };
    q.Dump();
    }
    
    // Define other methods and classes here
    public class Test{
    public string Machine { get; set; }
    public string Sample { get; set; }
    public string Experiment { get; set; }
    public DateTime DateCompleted { get; set; }
    }
