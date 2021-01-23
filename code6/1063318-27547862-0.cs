    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class DestroyByContact : MonoBehaviour
    {
	public GameObject explosion;
	public GameObject smoke;
	//public AudioMaster audioCall;
	public AudioClip audioCoinCollect;
	public AudioClip audioExplosion;
	private SpriteRenderer spriteRenderer;
	//private ScoreManager scoreManager;
	void OnTriggerEnter2D(Collider2D other)
	{	
		if (this.gameObject.tag == "Player" && other.tag == "Enemy") 
		{
			//AudioMaster.
			//audio.PlayOneShot (audioExplosion);
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (this.gameObject.tag == "PlayerWeapon" && other.tag == "Enemy") 
		{	
			audio.PlayOneShot (audioExplosion);
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			ScoreMaster.score += 100;
		}
		if (this.gameObject.tag == "Enemy" && other.tag == "Player") 
		{	
			audio.PlayOneShot (audioExplosion);
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Instantiate (explosion, this.transform.position, this.transform.rotation);//change this to 
     different explosion for player
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (this.gameObject.tag == "Player" && other.tag == "PowerUps") 
		{	
			if (other.gameObject.name == "dragonmask(Clone)")
			{
				PlayerController.speed = 1;
			}
			else if (other.name == "powerupdragoneye(Clone)")
			{
				PlayerController.speed = 8;
			}
			else if (other.gameObject.name == "powerupskull(Clone)")
			{
				PlayerController.speed = 25;
			}
			else if (other.gameObject.name == "powerupmushroom(Clone)")
			{
				PlayerController.speed = 50;
			}
			audio.PlayOneShot (audioCoinCollect);
			Instantiate (smoke, other.transform.position, other.transform.rotation); //may be changed        
     to points later.
			Destroy (other.gameObject);
			Debug.Log("Power Up Type "+ other.gameObject.name);
     //			GameObject.Find("GameController").GetComponent("GameMaster");
     //			if (other.gameObject = mushroom)
     //			{
     //
     //			}
			//will add gem collected or powerup to player here.
			//Destroy (gameObject);
		}
		if (this.gameObject.tag == "Player" && other.tag == "Coin") 
		{	
			if (other.gameObject.name == "coin4(Clone)")
			{
				CoinMaster.coins += 1;
			}
			else if (other.name == "purplegem(Clone)")
			{
				CoinMaster.coins += 5;
			}
			else if (other.gameObject.name == "redgem(Clone)")
			{
				CoinMaster.coins += 4;
			}
			else if (other.gameObject.name == "bluegem(Clone)")
			{
				CoinMaster.coins += 3;
			}
			audio.PlayOneShot (audioCoinCollect);
			Instantiate (smoke, other.transform.position, other.transform.rotation); //may be changed 
     to points later.
			Destroy (other.gameObject);
			Debug.Log("coin type "+ other.gameObject.name);
			//will add coins to coin score 
			//Destroy (gameObject);
		}
			////(explosion, transform.position, transform.rotation);
		//if (other.tag == "Player")
		///{
		//	Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				//(explosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver ();
		//}
		//Destroy(other.gameObject);
		//Destroy(gameObject);
		//Debug.Log ("Explosion should happen");
	}
      }
