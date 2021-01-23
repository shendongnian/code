    using UnityEngine;
    using UnityEngine.UI; // New Unity UI system from Unity 4.6 version
    
    namespace TestExample {
    	public class TestNewUI : MonoBehaviour 
    	{
    		public Image image;
    		
    		public Slider slider;
    
            private Sprite _sprite;
    
        	void Start()
        	{
    			_sprite = image.sprite;
        	}
    	}
    }
