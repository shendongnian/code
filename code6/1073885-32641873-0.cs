    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    
    public class TextFlicker : MonoBehaviour {
    	float blinkDurationSecs =1f;
    	float blinkProgress =0f;
    	float blinkStep = 0.01f;
    	//Color txtColor = Color.black;
    	Text blinkingText;
    	// Use this for initialization
    	void Start () {
    		blinkingText = GetComponentInParent<Text>();
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		if ((blinkProgress > 1)||(blinkProgress<0)) {
    			blinkStep*=-1f;
    		} 
    		blinkProgress+=blinkStep;
    		blinkingText.color = Color.Lerp (Color.black, Color.white, blinkProgress);// or whatever color you choose
    	}
    }
