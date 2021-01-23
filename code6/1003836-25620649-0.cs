    public List<object> BoothsInGroup1 { get; set; }
    
    BoothsInGroup1 = new List<object>();
    
    BoothsInGroup1.Add(new { BoothID = da["BoothID"].ToString(), BoothName = da["BoothName"].ToString() });
    
    
    var Booth = (LstGroup1.SelectedItem);
    var output = Booth.BoothID;
