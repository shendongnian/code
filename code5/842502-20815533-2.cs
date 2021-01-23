    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class pictures : MonoBehaviour {
	
    	public GameObject[] pictures;	
	    public GameObject player;
	    List<string> oldnames = new List<string>();
    	public Texture  old;
	    public string oldName;
		// Use this for initialization
		void Start () {
		
	 		player = GameObject.FindGameObjectWithTag("Player");	
    		pictures = GameObject.FindGameObjectsWithTag( "pictures" );
	        foreach(GameObject picture in pictures)
		    {
	    		old = picture.renderer.material.GetTexture ("_MainTex");
    			oldName = old.name;
				oldnames.Add(oldName);
			}
		}
	
    	void MyFunction(GameObject picture, string name) {
    		Texture2D tex =	(Texture2D) Resources.Load(name, typeof(Texture2D));
			picture.renderer.material.mainTexture = tex;
	    }
		// Update is called once per frame
    	void Update () {
			for(int i = 0; i < pictures.Length; i++)
			{ 
				GameObject picture = vetrine[i];			
		
				if (Vector3.Distance(picture.transform.position, player.transform.position) < 10)
            	{
		        	MyFunction(picture, picture.name);
	            } 
				else 
				{ 
					MyFunction(picture, oldnames[i]);
				}
    		}
		}		
	}
