     public Angle(int deg, int min, int sec)
     {
         //Omitting input values check.
         double seconds = sec + 60 * (min + 60 * normalize(deg));
         value = seconds * Math.PI / 648000f;
     }
     private int normalize(int deg)
     {
         int normalizedDeg = deg % 360;
         if (normalizedDeg <= -180)
             normalizedDeg += 360;
         else if (normalizedDeg > 180)
             normalizedDeg -= 360;
         return normalizedDeg;
     }
