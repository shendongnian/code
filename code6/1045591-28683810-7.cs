    using System;
    using System.Collections;
    using UnityEngine;
    public class RayCaster {
    	public Transform StartTransform;
    	public Transform EndTransform;
    	public Vector3 Direction;
    	public float RayLength;
    	public int LayerMask = 0;
    	public event Action<Collider> OnRayEnter;
    	public event Action<Collider> OnRayStay;
    	public event Action<Collider> OnRayExit;
    	Collider previous;
    	RaycastHit hit = new RaycastHit();
    	public bool CastRay() {
    		// We hit something!
    		if (Physics.Raycast(StartTransform.position, Direction, out hit, RayLength, LayerMask)) {
    			ProcessCollision(hit.collider);
    			return true;
    		}
    		// Nothing was hit!
    		else {
    			ProcessCollision(null);
    			return false;
    		}
    	}
    	public bool CastLine() {
    		// We hit something!
    		if (Physics.Linecast(StartTransform.position, EndTransform.position, out hit, LayerMask)) {
    			ProcessCollision(hit.collider);
    			return true;
    		}
    		// Nothing was hit!
    		else {
    			ProcessCollision(null);
    			return false;
    		}
    	}
    	private void ProcessCollision(Collider current) {
    		// No collision this frame.
    		if (current == null) {
    			// There was an object being hit last frame, but not this frame.
    			if (previous != null) {
    				DoEvent(OnRayExit, previous);
    			}
    		}
    		// The collided object is the same as last frame.
    		else if (previous == current) {
    			DoEvent(OnRayStay, current);
    		}
    		// The collided object is different than last frame.
    		else if (previous != null) {
    			DoEvent(OnRayExit, previous);
    			DoEvent(OnRayEnter, current);
    		}
    		// Just starting a new collision (and no collision last frame)
    		else {
    			DoEvent(OnRayEnter, current);
    		}
    		// Remember this collision for comparing with next frame.
    		previous = current;
    	}
    	private void DoEvent(Action<Collider> action, Collider collider) {
    		if (action != null) {
    			action(collider);
    		}
    	}
		public static int GetLayerMask(string layerName, int existingMask=0) {
			int layer = LayerMask.NameToLayer(layerName);
			return existingMask | (1 << layer);
		}
    }
