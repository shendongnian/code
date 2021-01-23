    class ColliderManager
    {
    	Dictionary<TKey, Collider> colliders;
    	Dictionary<Vector2, List<TKey>> collidersByChunks;
    
    	public void AddCollider(TKey pKey, Collider pCOllider)
    	{
    		this.colliders.Add(pKey, pCollider);
    		
    		foreach(Vector2 chunkCoord in this.GetChunkCoords(pCollider.Rectangle))
    		{
    			List<TKey> collidersAtChunk = null;
    			if(!this.collidersByChunks.TryGetValue(chunkCoord, out collidersAtChunk))
    			{
    				collidersAtChunk = new List<TKey>();
    				this.collidersByChunks.Add(chunkCoords, collidersAtChunk);
    			}
    			
    			collidersAtChunk.Add(pKey, pCollider);
    		}
    	}
    	
    	private Vector2[] GetChunkCoords(Rectangle pRectangle)
    	{
    		// return all chunks pRectangle intersects
    	}
    }
