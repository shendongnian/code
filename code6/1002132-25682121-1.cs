    public Polyline mergePaths(Shape line1, Shape line2)
    {
         if(!checkLineType(line1) || !checkLineType(line2))
         {
             return null;
         }
         if(hitTest(line1, line2))
         {
             //here you have to do some math to determine the overlapping points
             //on these points you can do something like this:
             
             foreach(Point p in Overlapping Points)
             {
                  //add the first line until p then add line2 and go on to add lin 1 until another p
             }
         }
         else
         {
             return null;
         }         
    }
