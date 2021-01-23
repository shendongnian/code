    ...
        if (rayMeshResult != null)
           {
              GeometryModel3D hitgeo = rayMeshResult.ModelHit as GeometryModel3D;
              foreach (string s in List)
              {
               if (hitgeo.Equals(FindName(s)))
               {
                   //do something
               }
             }
           }
