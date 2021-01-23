    public interface INode  {void SomeAccessableMethod(); }
    internal  class Vector3  {}
    internal class Node : INode
    {
      public void SomeAccessableMethod() {}
      public Vector3[] CameraPositions { get; set; }
    }
    public class Path
    {
     private readonly IList<INode> _nodesInPath = new List<INode>();
     public Path()
     {
       //Initalise all the nodes
       for(int cnt = 0; cnt < 10; cnt++)
       {
         var node = new Node();
         node.CameraPositions = new Vector3[1];
         node.CameraPositions[0] = new Vector3();
         _nodesInPath.Add(new Node());
       }
     }
     public INode[] NodesInPath
     {
       get { return _nodesInPath.ToArray(); }
     }
    }
