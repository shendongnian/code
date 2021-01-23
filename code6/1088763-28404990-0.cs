    using UnityEngine;
    using System.Collections;
    public class DestroyerScript : MonoBehaviour {
	
	bool dead;
	
	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			yield return new WaitForSeconds(5);
			Application.LoadLevel("GameOverScene");
			dead = true;
			return dead;
		}
	}
    }
 
