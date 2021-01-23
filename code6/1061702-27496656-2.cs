	public class SpawnManager
	{
        public float lifeTime;
		...
		void Update()
		{
			lifeTime -= Time.deltaTime
			
			if (lifeTime <= 0)
			{
				Destroy (_spawndEnemy, transport);
                SpawnEnemy()
			}
		}
	}
    
