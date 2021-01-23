    public class SpawnPoint : MonoBehaviour
    {
    	void OnTriggerEnter2D(Collider2D other)
    	{
    		if (other.tag == "Player")
    		{
    			var playerController = other.GetComponent<PinkPlayerControler>();
    			playerControler.spawnPosition = transform.position;
    		}
    	}
    }
