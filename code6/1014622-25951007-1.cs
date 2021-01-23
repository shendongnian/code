    public interface INode
    {
        void DoPublic();
    }
    
    // As it is pointed by @xmomjr
    internal class Node : INode
    {
        public void DoPublic(){}
        public void DoHidden(){}
    }
    
    public class MyList
    {
        public void Process(INode node)
        {
            if (node is Node)
                // ...
        }
    }
