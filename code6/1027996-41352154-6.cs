    public class Shooter : MonoBehaviour {
    
    	public GameObject projectile;
    	public GameObject gun;
    
    	private GameObject projectileParent;
    
    	void Start ()
    	{
    		projectileParent = GameObject.Find ("Projectiles");
    
    		if (!projectileParent) {
    			projectileParent = new GameObject();
    			projectileParent.name = "Projectiles";
    		}
    	}
    
    	private void Fire (){
    		GameObject newProjectile = Instantiate(projectile) as GameObject;
    		newProjectile.transform.parent = projectileParent.transform;
    		newProjectile.transform.position = gun.transform.position;
    	}
    }
