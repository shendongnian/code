    using UnityEngine;
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
    	public static T Instance { get; private set; }
    
    	protected virtual void Awake()
    	{
    		if (Instance == null)
    		{
    			Instance = (T) this;
    		}
    		else
    		{
    			Debug.LogError("Got a second instance of the class " + this.GetType());
    		}
    	}
    }
