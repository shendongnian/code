    namespace Chess
    {
    	/// <summary>
    	/// Implements using a binary search tree.
    	/// Is thread-safe when adding, not when removing.
    	/// </summary>
    	public class BinaryTree
    	{
    		public MiniMax.Node info;
    		public BinaryTree left, right;
    
    		/// <summary>
    		/// Collisions are handled by returning the existing node. Thread-safe
    		/// Does not recalculate height, do that after all positions are added.
    		/// </summary>
    		/// <param name="info">Connector in a tree structure</param>
    		/// <returns>Node the position was already store in, null if new node.</returns>
    		public MiniMax.Node AddConnection(MiniMax.Node chessNode)
    		{
    			if (this.info == null)
    			{
    				lock (this)
    				{
    					// Must check again, in case it was changed before lock.
    					if (this.info == null)
    					{
    						this.left = new BinaryTree();
    						this.right = new BinaryTree();
    						this.info = chessNode;
    						return null;
    					}
    				}
    			}
    
    			int difference = this.info.position.CompareTo(chessNode.position);
    
    			if (difference < 0) return this.left.AddConnection(chessNode);
    			else if (difference > 0) return this.right.AddConnection(chessNode);
    			else
    			{
    				this.info.IncreaseReferenceCount();
    				return this.info;
    			}
    		}
    
    		/// <summary>
    		/// Construct a new Binary search tree from an array.
    		/// </summary>
    		/// <param name="elements">Array of elements, inorder.</param>
    		/// <param name="min">First element of this branch.</param>
    		/// <param name="max">Last element of this branch.</param>
    		public void CreateFromArray(MiniMax.Node[] elements, int min, int max)
    		{
    			if (max >= min)
    			{
    				int mid = (min + max) >> 1;
    				this.info = elements[mid];
    
    				this.left = new BinaryTree();
    				this.right = new BinaryTree();
    
    				// The left and right each have one half of the array, exept the mid.
    				this.left.CreateFromArray(elements, min, mid - 1);
    				this.right.CreateFromArray(elements, mid + 1, max);
    			}
    		}
    
    		public void CollectUnmarked(MiniMax.Node[] restructure, ref int index)
    		{
    			if (this.info != null)
    			{
    				this.left.CollectUnmarked(restructure, ref index);
    
    				// Nodes marked for removal will not be added to the array.
    				if (!this.info.Marked)
    					restructure[index++] = this.info;
    
    				this.right.CollectUnmarked(restructure, ref index);
    			}
    		}
    
    		public int Unmark()
    		{
    			if (this.info != null)
    			{
    				this.info.Marked = false;
    				return this.left.Unmark() + this.right.Unmark() + 1;
    			}
    			else return 0;
    		}
    	}
    }
