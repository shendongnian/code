      public struct Point3D
      {
      public   int x {get;set;}
      public   int y {get;set;}
      public   int z {get;set;}
      public   int value {get;set;}
     //any other properties....
      }
    
    List<Point3D>MyPoints=new List<Point3D>();
    //to check if something exists by my coordinates:
    
    List<Point3D> ResultList=MyPoints.FindAll(coords=>coords.x==25&&coords.y==250&&coords.z==70);
    if(ResultList.Count>0) //points exists
    {
      // do something with ResultList[0], that should contains your point data
    }
