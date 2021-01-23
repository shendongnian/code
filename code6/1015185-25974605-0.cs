    public class WayPointPositioner : MonoBehaviour {
	private Vector3 wayPointPosition;
	private bool checkPlayerWaypointCollision;
	void Start()
	{
		wayPointPosition = transform.position;
	}
	void OnTriggerStay2D (Collider2D other) 
	{
		if (other.gameObject.name == "Player")
		{
			checkPlayerWaypointCollision = true;
		}
		else
		{
			checkPlayerWaypointCollision = false;
		}
	}
	//Check if object is clicked
	void OnMouseDown () 
	{
	
		// If its the player, then return a new position for the player to move to for walking
		// Else debug that its not so
			if (checkPlayerWaypointCollision == false)
			{
				Debug.Log ("Object not colliding and retrieving position");
				transform.position = new Vector3 (transform.position.x, transform.position.y, 10);
				wayPointPosition = Camera.main.ScreenToWorldPoint(wayPointPosition);
			}
			else
			{
				Debug.Log ("Object is colliding, no movement needed");
			}
	}
    }
