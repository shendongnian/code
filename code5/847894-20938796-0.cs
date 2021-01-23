    double[] pastPoints = new double[4]; //id,x,y,z
    IntPtr a = Marshal.AllocCoTaskMem(sizeof(double) * pastPoints.Length);  // Allocate memory for result
    path.GetPoint(i, a);    // Generate result.
    Marshal.Copy(a, pastPoints, 0, pastPoints.Length);    // Copy result to array.
    Marshal.FreeCoTaskMem(a);
    System.Console.WriteLine(pastPoints[0]);
    System.Console.WriteLine(pastPoints[1]);
    System.Console.WriteLine(pastPoints[2]);
    System.Console.WriteLine(pastPoints[3]);
   
