    if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
					Vector3 playerToMouse = floorHit.point - transform.position;
				
					// the quaternion defines the rotation, looking through the vector
					Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
					playerRigidbody.MoveRotation (newRotation);
				
					toGo = floorHit.point; // We save the point we touched  }
   
