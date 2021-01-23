	class Timer : MonoBehaviour
	{
		public float SecondsToWait;
		private float timeCounter;
		
		void OnEnable() {
			timeCounter = 0;
		}
		void Update() {
			timeCounter += Time.deltaTime;
			if(timeCounter >= SecondsToWait)
			{
				enabled = false; //Disable this object
				doMyMethod();
			}
		}
		private void doMyMethod() {
			Debug.Log("Doing stuff!");
		}
	}
