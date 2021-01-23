    public class SpawnOnXaxis : MonoBehaviour {
    public GameObject Goodfood;
    public int numToSpawn;
    public Vector3 position;
    void Awake()        
    {
        position = new Vector3(Random.Range(-9.0F, 9.0F), 10.5f, -1); // -9 på Xaxis - +9 ----- Y = 10.5 z = -1
        numToSpawn = 10;
    }
    void Start() 
    {
        int spawned = 0;
        while (spawned < numToSpawn)
        {
            position = new Vector3(Random.Range(-9.0F, 9.0F), 10.5f, Random.Range(-9.0F, 9.0F));
            GameObject tmp = Instantiate(Goodfood, position, Quaternion.identity) as GameObject; // Quaternion.identity betyder "ingen rotation"
            spawned++;
            System.Threading.Thread.Sleep(500);
        }
    }
    }
