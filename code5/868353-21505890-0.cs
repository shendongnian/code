    public class LinkList : ISerializable
    {
        public Node First { get; set; }
        public Node Tail { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Firts", First);
        }
        public LinkList(SerializationInfo info, StreamingContext context)
        {
            First = info.GetValue("First", typeof(Node)) as Node;
            First.PrevNode = null;
            //do one one while set the Tail of this class  and LinkList proeprty for each node
        }
    }
    public class Node : ISerializable
    {
        public LinkList LinkList { get; set; }
         
    
        public Node(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            NextNode = info.GetValue("NextNode", typeof(Node)) as Node;
            if(NextNode != null)
                NextNode.PrevNode = this;
        }
      public  Node PrevNode
        {
            get;
            set;
        }
        public Node NextNode
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
       
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Next", NextNode);
        }
    }
