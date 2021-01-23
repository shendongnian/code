     public static double GetNextSmallerRingRadius(double startingRingRadius, double circleRadius)
     {
         int numberOfCircles = (int)Math.Round(Math.PI / Math.Asin(circleRadius / startingRingRadius), 0); //There would need to be some logic to make sure input values are correct.
         Debug.Assert(numberOfCircles > 2);
         double centralAngle = 2 * Math.PI / (numberOfCircles - 1);
         return circleRadius / Math.Sin(centralAngle / 2);
     }
     public static double GetNextLargerRingRadius(double startingRingRadius, double circleRadius)
     {
         int numberOfCircles = (int)Math.Round(Math.PI / Math.Asin(circleRadius / startingRingRadius), 0); //There would need to be some logic to make sure input values are correct.
         Debug.Assert(numberOfCircles > 1);
         double centralAngle = 2 * Math.PI / (numberOfCircles + 1);
         return circleRadius / Math.Sin(centralAngle / 2);
     }
