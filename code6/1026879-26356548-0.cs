    Console.WriteLine("Add integer X: ");
    int x = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Add integer Y: ");
    int y = Convert.ToInt32(Console.ReadLine());
    
    Triangle Tri1 = new Triangle(x, y);            
    Console.WriteLine("Area 1=" + Tri1.TriArea()); 
