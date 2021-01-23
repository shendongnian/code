    using System;
    public struct Point
    {
      public int X;
      public Point(int initialValue) { X = initialValue; }
    }
    class Program
    {
      static void Main(string[] args)
      {
        Point point1 = new Point(5);
        Console.WriteLine("Before:" + point1.X);
        ChangePoint(point1);
        Console.WriteLine("After:" + point1.X);
        Console.ReadLine();
      }
      private static void ChangePoint(Point p)
      {
        p.X = 20;
      }
    }
