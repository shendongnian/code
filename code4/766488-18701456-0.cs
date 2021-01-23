     class Button {
         public float Duration = 1; // One second
         public Rectangle Bounds;   // Button boundaries
         public float Progress { get{ return Elapsed/Duration; } }
         float Elapsed = 0;
         
         public void Update(float ft) {
              if (Bounds.Contains( HandPosition ))
              {
                   if (Elapsed<Duration) {
                       Elapsed += ft;
                       if (Elapsed>Duration) {
                           Elapsed = Duration;
                           OnClick();
                       }
                   }
              } else {
                 Elapsed = 0;
              }
         }      
     }
