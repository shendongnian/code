	public void Delete(Node n)
	{
		if (root == node) 
		{
			root = n.next;
			n.next = null;
		}
		else
		{
			Node curr = root;
			while (curr.next != null)
			{
				if (curr.next == n)
				{
					curr.next = n.next;
					n.next = null;
					break;
				}
				curr = curr.next;
			}
		}
	}
