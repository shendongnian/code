    public class DirectoryInfoComparer : IEqualityComparer<System.IO.DirectoryInfo>
    {
      public bool Equals(System.IO.DirectoryInfo x, System.IO.DirectoryInfo y)
      {
        if (object.ReferenceEquals(x, y))
          return true;
        if (x == null || y == null)
          return false;
        return x.FullName == y.FullName;
      }
      public int GetHashCode(System.IO.DirectoryInfo obj)
      {
        if (obj == null)
          return 0;
        return obj.FullName.GetHashCode();
      }
    }
    System.IO.DirectoryInfo[] otherDirectory = 
          AllDir.Except<DirectoryInfo>(MaryDir, new DirectoryInfoComparer()).Except(JackDir, new DirectoryInfoComparer()).ToArray();
