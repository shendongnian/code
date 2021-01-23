    var myHoles = new Holes();
    var myOrders = new Orders();
    var myTools = new Tools();
    var myToolHoles = new ToolHoles();
    myJob.Holes.Add(myHoles);  //myJob already exists
    myJob.Orders.Add(myOrders);
    myHoles.Tools.Add(myTools);
    myOrders.Tools.Add(myTools);
    myHoles.ToolHoles.Add(myToolHoles);
    myOrders.ToolHoles.Add(myToolHoles);
    db.SaveChanges();
