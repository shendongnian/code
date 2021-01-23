		public float end_time = 10.0f;
		public float start_time;
		private float running_time;
		// Use this for initialization
		void Start () 
		{
			start_time = Time.deltaTime;
			running_time = 0f;
		}
		// Update is called once per frame
		void Update () 
		{
			EyeTarget();
		}
		void EyeTarget()
		{
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			if (Physics.Raycast(transform.position, fwd, out hit))
			{
			 //  Debug.Log("ray hit (tag): " + hit.collider.gameObject.tag + " : ");
				if(hit.collider.gameObject.tag == "floor")
				{
					Debug.Log("Just hit the floor");
					start_time = Time.time - end_time;
					running_time += Time.deltaTime
					//if(start_time <= 0)
					if ( running_time >= end_time )
					{
						Debug.Log("looked at floor for 10 seconds");
					}
				}
				if( hit.collider.gameObject.tag != "floor")
				{
					ResetTimer();
				}
			}
			Debug.DrawRay(transform.position, fwd, Color.green);
		}
		void ResetTimer()
		{
			start_time = Time.time;
			running_time = 0f;
			Debug.Log("resetting timer");
		}
