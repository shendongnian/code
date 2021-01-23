    public class LinkedListC89<T> : IEnumerable<T>
    {
       private class Node<T>
       {
          public int Prev;
          public int Next;
          public T Value;
       }
       private Node[] nodes;
       private Node first;
    
       public IEnumerator<T> GetEnumerator()
       {
            Node curNode = first;
    
            While (curNode != null)
            {
                yield return curNode.Value;
                if (curNode.Next>nodes.Length) yield break;
                curNode = nodes[curNode.Next]
            }
       }
    }
