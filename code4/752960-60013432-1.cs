       Camera.Projection = Matrix.CreatePerspectiveFieldOfView(2f * Math.Atan(Math.Tan(Camera.FieldofView / 2f) / CalculateYAspect(Camera.AspectRatio, 16f / 9f, 0) / Camera.ZoomFactor), Camera.AspectRatio, Camera.NearPlane, Camera.FarPlane)
       
       public float CalculateYAspect(float AspectRatio, float ConditionalAspect, int AspectAxisConstraint)
       {
           switch(AspectAxisConstraint)
           {
              default:
                 if (AspectRatio < ConditionalAspect)
                 {
                    goto case 2
                 }
                 else
                 {
                    goto case 1
                 }
              case 1:
                 return ConditionalAspect / ConditionalAspect
              case 2:
                 return AspectRatio / ConditionalAspect
           }
       }
