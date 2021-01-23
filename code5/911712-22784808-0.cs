    function OnCollisionStay(collision : Collision) {
		for (var contact : ContactPoint in collision.contacts) {
			print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
			// Visualize the contact point
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
	}
