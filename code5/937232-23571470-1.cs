    using System.Collections.Generic;
    //Somewhere in the class
    List<Wheel> myWheels = new List<Wheel>();
    
    // In your method
    var _wheel = new Wheel();
    
    // Set your properties
    
    myWheels.Add(_wheel);
    //Then when needed, you can loop like this:
    foreach(var wheel in myWheels)
    {
         // do something with wheel...
    }
