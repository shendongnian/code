    public struct Point3D
    {
        public   int x {get;set;}
        public   int y {get;set;}
        public   int z {get;set;}
        public   int value {get;set;}
        //any other properties....
    }
    public class Box
    {
        public int width {get; set;}
        public int length {get; set;}
        public int height {get; set;}
    }
    public class ContainerItem
    {
        public Box box {get; set;}
        public Point3D boxPlacement {get; set;}
        public Container container {get; set;}
    }
    public class Container
    {
        public int width {get; set;}
        public int length {get; set;}
        public int height {get; set;}
        public List<ContainerItem> boxes {get; set;}
    }
