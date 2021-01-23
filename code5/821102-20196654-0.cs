    [DataContract]
    public class Grid
    {
       [DataMember]
       public Point3D[] p = new Point3D[8];
      
       [DataMember]
       public Int32[] val = new Int32[8];
    }
