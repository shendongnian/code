    using UnityEngine;
    using System.Collections;
    public class DoorBehav : MonoBehaviour {
	public static float DoorHp = 100f;
	public TextMesh HpText;
    public Material brokenMat;
    public Material particleMat;//the material for the particle renderer
    private GameObject hero;
	ParticleEmitter partEmit;
    ParticleRenderer partRend;// the new particle renderer
	void Start () {
        hero = GameObject.Find("Hero");
		partEmit = GetComponent<ParticleEmitter> ();
        partRend = GetComponent<ParticleRenderer>();//importing the particle renderer
  		HpText = transform.FindChild ("DoorHp").GetComponent<TextMesh>() as TextMesh;
		HpText.color = Color.green;
	}
	
	void Update () {
		if (Vector3.Distance (hero.transform.position, transform.position) < 1.8f)
		   {
            HeroBehaviour.agent.speed = 0;
			DoorHp-=1f;
			partEmit.Emit();
			HpText.text = ((Mathf.FloorToInt(DoorHp)).ToString()+"%");
			if(DoorHp <=60f)
			{
                transform.renderer.material = brokenMat;
                partRend.material = particleMat;//changing the particle renderer's material
				HpText.color = Color.yellow;
			}
			if(DoorHp <=30f)
			{
				HpText.color = Color.red;
			}
			if(DoorHp <=0)
			{
				//play sound : destroy door
                HeroBehaviour.agent.speed = HeroBehaviour.moveSpeed; 
				Destroy(this.gameObject);
			}
		}
	}
    }    
