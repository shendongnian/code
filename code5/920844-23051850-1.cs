    for(int i = L/Math.Sqrt(3); i <= 2*L/Math.Sqrt(3); i++)
    {
         for (int j = 0; j <= Math.Sqrt(3)*i-2*L; j++)
         {
              pointsInHexagonQuadrant.Add(new Point(i,j));
         }
    }
