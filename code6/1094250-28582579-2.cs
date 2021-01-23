    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System;
    
    public class Counter : MonoBehaviour
    {
    
    		public Text counterText, pauseText, resumeText, msgText;
    		private int counterValue, focusCounter, pauseCounter;
    		private DateTime lastMinimize;
    		private double minimizedSeconds;
    		
    		void OnApplicationPause (bool isGamePause)
    		{
    				if (isGamePause) {
    						pauseCounter++;
    						pauseText.text = "Paused : " + pauseCounter;
    						GoToMinimize ();
    				} 
    		}
    
    		void OnApplicationFocus (bool isGameFocus)
    		{
    				if (isGameFocus) {
    						focusCounter++;
    						resumeText.text = "Focused : " + focusCounter;
    						GoToMaximize ();
    				} 
    		}
    
    		// Use this for initialization
    		void Start ()
    		{
    				StartCoroutine ("StartCounter");
    				Application.runInBackground = true;
    		}
    	
    		IEnumerator StartCounter ()
    		{
    				yield return new WaitForSeconds (1f);
    				counterText.text = "Counter : " + counterValue.ToString ();
    				counterValue++;
    				StartCoroutine ("StartCounter");
    		}
    	
    		public void GoToMinimize ()
    		{
    				lastMinimize = DateTime.Now;
    		}
    
    		public void GoToMaximize ()
    		{
    				if (focusCounter >= 2) {
    						minimizedSeconds = (DateTime.Now - lastMinimize).TotalSeconds;
    						msgText.text = "Total Minimized Seconds : " + minimizedSeconds.ToString ();
    						counterValue += (Int32)minimizedSeconds;
    				}
    				
    		}
    		
    
    }
