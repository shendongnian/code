    using System;
    namespace LinkedList
    {
    	class LinkedList
    	{
    
    		public static void Main(String[] args){
    			var list = new LinkedList();
    
    			list.Insert (1);
    			list.Insert (2);
    			list.Insert (3);
    			list.Insert (4);
    
    			var node = list.Head;
    			do {
    				Console.Out.WriteLine (node.Value);
    
    			} while((node = node.Next) != null);
    		}
    			
    		private Node _dummy;
    		private Node _head;
    		private Node _tail;
    
    		public Node Head { get { return _head; }}
    
    		public LinkedList(){
    			_dummy = new Node(null, null);
    			_head = _dummy;
    			_tail = _dummy;
    		}
    
    		public void Insert(int value){
    			_head = new Node(_head, value);
    		}
    			
    		public class Node{
    
    			public int? Value { get; set; }
    			public Node Next { get; set;}
    
    			public Node(Node next, int? value){
    				Value = value;
    				Next = next;
    			}
    		}
    	}
    }
