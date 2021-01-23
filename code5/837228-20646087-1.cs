    public class LinkedListStack<T>
    {
      /// <summary>
      /// indicates whether or not the stack contains data
      /// </summary>
      public bool HasData { get { return this.Top != null ; } }
      
      /// <summary>
      /// The topmost stack frame
      /// </summary>
      private Node Top { get ; set; }
      
      /// <summary>
      /// constructor
      /// </summary>
      public LinkedListStack()
      {
        this.Top   = null ;
        return ;
      }
      
      /// <summary>
      /// constructor: initializes the stack with the provied contents.
      /// </summary>
      /// <param name="data"></param>
      public LinkedListStack( IEnumerable<T> data ) : this()
      {
        if ( data == null ) throw new ArgumentNullException("data") ;
        foreach ( T datum in data )
        {
          Push(datum) ;
        }
      }
      
      /// <summary>
      /// remove the top item from the stack and return it
      /// </summary>
      /// <returns></returns>
      public T Pop()
      {
        if ( this.Top == null ) throw new InvalidOperationException("Can't pop an empty stack!");
        Node top = this.Top ;
        this.Top = top.Next ;
        return top.Payload ;
      }
      
      /// <summary>
      /// push an item onto the stack
      /// </summary>
      /// <param name="datum"></param>
      public void Push( T datum )
      {
        this.Top = new Node( datum , this.Top ) ;
        return ;
      }
      
      /// <summary>
      /// private helper class (our stack frame)
      /// </summary>
      private class Node
      {
        public Node Next    ;
        public T    Payload ;
        public Node( T payload ) : this(payload,null)
        {
          return ;
        }
        public Node( T payload , Node next )
        {
          this.Next = next ;
          this.Payload = payload ;
          return ;
        }
      }
      
    }
