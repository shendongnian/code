    public interface INode
    {
        void DoPublic();
    }
    
    public class Node : INode
    {
        public void DoPublic(){}
        internal void DoHidden(){}
    }
    
    public class MyList
    {
        void Process(INode node)
        {
            if (node is Node)
                // ...
        }
    }
