	using UnityEngine;
	using System.Collections;
	
	public class OuterPlaceholder: MonoBehaviour {
	
	      public InnerBehavior _Inner;
	      public void Awake() {
	           if (_Inner == null) {
	           _Inner= new InnerBehavior(4);
			}
	  	}
	
	     public void Update()
	     { 
	        _Inner.DoUpdate(this);
	     }
	
	}
	
	public class InnerBehavior 
	{
	     public readonly int UpConstant;
	     public InnerBehavior (int up)
	     {
	     UpConstant = up;
	     }
	
	     public void DoUpdate(MonoBehaviour owner)
	     {
	      owner.transform.Translate(Vector3.up * UpConstant * Time.deltaTime);
	     }
	
	}
