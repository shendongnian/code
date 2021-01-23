    public List<Booth> BoothsInGroup1 { get; set; }
    BoothsInGroup1.Add(new Booth{ BoothID = da["BoothID"].ToString(), BoothName = da["BoothName"].ToString() });
    ....
    var myBooth = LstGroup1.SelectedItem;
    String id =myBooth.BoothID;
    String name=myBooth.BoothName:
