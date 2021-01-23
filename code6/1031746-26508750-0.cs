    public class bomb : MonoBehaviour {
	BoxCollider collider;
	void Start () {
		collider = gameObject.GetComponent<BoxCollider> ();
	}
	void OnTriggerExit(Collider other)
	{
		collider.isTrigger = false;
	}
