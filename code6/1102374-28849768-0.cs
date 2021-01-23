    class CompareDistance
    {
    	public float DistanceToCameraPlane(Vector3 pointInSpace)
    	{
    		var cameraPosition = Camera.main.transform.position;
    		var cameraForward = Camera.main.transform.forward;
    		var deltaToCamera = pointInSpace - cameraPosition;
    		var projection = Vector3.Project(deltaToCamera, cameraForward);
    		return projection.magnitude;
    	}
    }
