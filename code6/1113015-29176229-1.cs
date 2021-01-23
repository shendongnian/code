	using UnityEngine;
	using System.Collections;
	public class Elevator : MonoBehaviour {
		public Transform[] waypoint;    // The amount of Waypoint you want
		float patrolSpeed = 3.0f;       // The walking speed between Waypoints
		float dampingLook = 6.0f;       // How slowly to turn
		public float pauseDuration;     // How long to pause at a Waypoint
		float curTime;
		int  currentWaypoint;
		void Update()
		{
			if (currentWaypoint < waypoint.Length)
				Patrol();
			else
				currentWaypoint = 0;
		}
		
		void Patrol()
		{
			Vector3 target = waypoint[currentWaypoint].position;
			Vector3 moveDirection = target - transform.position;
			if(moveDirection.magnitude < 0.5)
			{
				if (curTime == 0)
					curTime = Time.time;        // Pause over the Waypoint
				if ((Time.time - curTime) >= pauseDuration)
				{
					currentWaypoint = Random.Range(0, waypoint.Length);
					curTime = 0;
				}
			}
			else
			{
				transform.Translate(moveDirection.normalized * patrolSpeed * Time.deltaTime);
			}   
		}
	}
