    using UnityEngine;
    using System.Collections.Generic;
    
    public class Distance
    {
       public float distance;
       public int index;
    
       public Distance( float distance, int index )
       {
          this.distance = distance;
          this.index = index;
       }
    }
    
    class MyGame
    {
       Vector3[] positions;
       Vector3 myObject;
       Vector3[] four = new Vector3[4];
    
       List<Distance> distanceList = new List<Distance>();
    
       void Foo()
       {
          for( int i = 0; i < positions.Length; i++ )
          {
             // get all the distances
             float distance = Vector3.Distance( positions[i], myObject );
             // store the distance with the index of the position
             distanceList.Add( new Distance( distance, i ) );
          }
    
          // sort the distances
          distanceList.Sort( delegate (Distance t1, Distance t2) { return (t1.distance.CompareTo(t2.distance)); } );
    
          for( int i = 0; i < 4; i++ )
          {
             // get the first four sorted distances
             int idx = distanceList[i].index;
             // use the stored index
             four[i] = positions[idx];
          }
       }
    }
