    public GameObject FindClosestGameObject(int startingLookUpDistance, int maxLookUpDistance, int numberOfSteps)
	{
		GameObject closestGameObject = gameObject.ReturnClosestObject(startingLookUpDistance, LayerMasks.gameObjects);		
		
		bool gameObjectNotFound = (closestGameObject.Equals(null));
		
		if(gameObjectNotFound)
		{
			if(startingLookUpDistance <= maxLookUpDistance)
			{
				float stepDistance = maxLookUpDistance / numberOfSteps;
				return FindClosestBuildingObject((int)(startingLookUpDistance + stepDistance), maxLookUpDistance, numberOfSteps);
			}			
			
			return null;
		}
		else
		{
			return closestGameObject;		
		}
	}
