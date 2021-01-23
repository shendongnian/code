    public class CharacterInput : MonoBehaviour
    {
	    public Transform CharacterTransform;
	    public float RotationSmoothingCoef = 0.1f;
	    void Update()
	    {
		    var groundPlane = new Plane(Vector3.up, -CharacterTransform.position.y);
		    var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		    float hitDistance;
		    if (groundPlane.Raycast(mouseRay, out hitDistance))
		    {
			    var lookAtPosition = mouseRay.GetPoint(hitDistance);
			    var targetRotation = Quaternion.LookRotation(lookAtPosition - CharacterTransform.position, Vector3.up);
			    var rotation = Quaternion.Lerp(CharacterTransform.rotation, targetRotation, RotationSmoothingCoef);
			    CharacterTransform.rotation = rotation;
		    }
	    }
	}
