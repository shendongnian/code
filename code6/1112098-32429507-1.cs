    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class SoundController : MonoBehaviour {
    	public AudioClip clip;	
    	
    	void Start () {
    		AudioSource.PlayClipAtPoint(clip, Vector3.zero, 1.0f);		
    	}
    }
