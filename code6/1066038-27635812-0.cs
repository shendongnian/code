    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class LinkedList<T>
    {
        private Node<T> head;  // 1st node in the linked list
        private int count;
    
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    
        public Node<T> Head
        {
            get { return head; }
        }
        public LinkedList<T>()
        {
            head = null;    // creates an empty linked list
            count = 0;
        }
    
        public void AddFront(T z)
        {
            Node<T> newNode = new Node<T>(z);
            newNode.Link = head;
            head = newNode;
            count++;
    
        }
    
        public void DeleteFront()
        {
            if (count > 0)
            {
                head = head.Link;
                count--;
            }
        }
    
        public void DisplayAll()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Link;
            }
        }
    
    }
