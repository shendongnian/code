    void init()
    {
      array = new Point3dStruct[1000000];
    }
    double GetX(int index)
    { return array[index].X; }
    double SetX(int index, double value)
    { array[index].X = value; }
    double SetXYZ(int index, double x, double y, double z)
    { array[index].X = x; array[index].Y = y; array[index].Y = z; }
    void CopyCoord(int src, int dest)
    { array[dest] = array[src]; }
