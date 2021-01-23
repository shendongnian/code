    Vehicle veh = new Vehicle();
    Stack<Vehicle> StackVeh = new Stack<Vehicle>();
    
    StackVeh.Clear();
    
    veh.Class = "A";
    veh.Speed = 280;
    veh.Active = true;
    StackVeh.Push(veh);
    
    veh = new Vehicle();
    veh.Class = "C";
    veh.Speed = 200;
    veh.Active = false;
    StackVeh.Push(veh);
    
    veh = new Vehicle();
    veh.Class = "B";
    veh.Speed = 160;
    veh.Active = true;
    StackVeh.Push(veh);
    
    veh = new Vehicle();
    veh.Class = "AAA";
    veh.Speed = 320;
    veh.Active = false;
    StackVeh.Push(veh);
    
    foreach (Vehicle v in StackVeh)
    {
       Console.WriteLine("\n");
       Console.WriteLine(v.Class);
       Console.WriteLine(v.Speed);
       Console.WriteLine(v.Active);
    }
