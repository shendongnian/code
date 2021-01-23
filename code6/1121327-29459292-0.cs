    public class CharacterInput : MonoBehaviour
    {
	    public Transform CharacterTransform;
	    void Update()
	    {
		    var groundPlane = new Plane(Vector3.up, -CharacterTransform.position.y);
		    var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		    float hitDistance;
		    if (groundPlane.Raycast(mouseRay, out hitDistance))
		    {
			    var lookAtPosition = mouseRay.GetPoint(hitDistance);
				CharacterTransform.LookAt(lookAtPosition, Vector3.up);
		    }
	    }
	}
