	public class Enemy
	{
		public GameObject enemyObject;
		public float lifeTime; //time in seconds
		
		public Enemy()
		{
			int rand = Random.Range(100, 600); //object will live between 10 and 60 seconds
			lifeTime = rand
		}
	}
	public class SpawnManager
	{
		public Enemy enemy = new List<Enemy>();
		void Update()
		{
			lifeTime -= Time.deltaTime
			
			if (lifeTime <= 0)
			{
				Destroy (_spawndEnemy, transport);
			}
		}
	}
