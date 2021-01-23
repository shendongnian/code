    public class TreeNode<T> where T:IComparable
    {
      public TreeNode<T> Left    { get ; set ; }
      public TreeNode<T> Right   { get ; set ; }
      public T           Payload { get ; set ; }
    }
