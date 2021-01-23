    public class Node
    {
       public bool Visited {get; set;}
       public int LinksNumber {get; set;}
       IList<Node> Links {get; private set;}
       public Node(Node n)
       {
          Visited = true;
          LinksNumber = 1;
          Links = new List<Node>() {n};
       }
    }
