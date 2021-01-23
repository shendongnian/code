    using KSP;
    using UnityEngine;
    using KerbalEconomy;
    
    namespace GetMoney { 
    
      class MoneyManager
      {
       public float  GetPrositon /* <---- Here it errors */
       {
            Vector3d point;
                double Longitude = vessel.mainBody.GetLongitude(point);
                double Latitude = vessel.mainBody.GetLatitude(point);
    
                double srfHeight = vessel.mainBody.pqsController.GetSurfaceHeight(
                        QuaternionD.AngleAxis(Longitude, Vector3d.down) *
                        QuaternionD.AngleAxis(Latitude, Vector3d.forward) * Vector3d.right) -
                              vessel.mainBody.pqsController.radius;
    
                double alt = (Vector3d.Distance(vessel.mainBody.transform.position, point) - vessel.mainBody.Radius); 
        }
    }
