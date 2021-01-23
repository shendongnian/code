    public class CountVisitor<T> : MyVisitor<T>
    {
        public int count { get; set;}
        public CountVisitor()
        {
          count = 0;
        }
    
        public void Visit(TreeStructure<T> tree)
        {
          if (tree is SpecialTree<T>)
              count += 2;
          else
              count++;
        }
    }
