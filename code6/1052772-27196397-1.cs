    static class NodeExtensions
    {
    	public static IEnumerable<Node> ReadChildNodes(this Node node)
    	{
    		foreach(Node childNode in node.ChildNodes){
    			if(childNode.ChildNodes != null && childNode.ChildNodes.Any()){
    				foreach(Node grandChildren in childNode.ReadChildNodes())
    					yield return grandChildren;
    			}
    			yield return childNode;
    		}
    	}
    }
