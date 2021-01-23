    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using System;
    
    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using System;
    
    public class BindingBehavior : MonoBehaviour
    {
    	public string BindingName;
    	public string TextInitialValue;
    
    	public Text TextComponent;
    
    	public string TextValue
    	{
    		get
    		{
    			if (TextComponent == null)
    			{
    				TextComponent = this.gameObject.GetComponent<Text>();
    			}
    			return TextComponent.text;
    		}
    		set
    		{
    			if (TextComponent == null)
    			{
    				TextComponent = this.gameObject.GetComponent<Text>();
    			}
    			TextComponent.text = value;
    		}
    	}
    
    	// Use this for initialization
    	void Start ()
    	{
    		TextValue = TextInitialValue;
    		UIManager.Instance.UITextBindings.Add(BindingName, TextComponent);
    	}
    }
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    public class UIManager 
    {
    	private static UIManager _instance;
    	public static UIManager Instance
    	{
    		get
    		{
    			if (_instance == null)
    			{
    				_instance = new UIManager();
    			}
    			return _instance;
    		}
    		set
    		{
    			_instance = value;
    		}
    	}
    
    	public Dictionary<string, Text> UITextBindings = new Dictionary<string, Text>();
    }
