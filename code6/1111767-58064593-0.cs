    public class BaseClass : MonoBehaviour
    {
    	// you'd normally start this using StartCoroutine( ... )
    	public IEnumerator Lerp( /*params*/ )
    	{
    		// this is (approx.) how monobehaviour internally manages the coroutines you start with StartCoroutine()
    		IEnumerator cInternalCoroutine = VInternalCoroutine( /*params*/ );
    
    		// each call to MoveNext() progresses the IEnumerator to the next yield 
    		// or end of the function if cInternalCoroutine.MoveNext() reaches the 
    		// end of the function, or it returns "yield break" MoveNext() returns false 
    		// & the loop ends
    		while( cInternalCoroutine.MoveNext() )
    		{
    			yield return cInternalCoroutine.Current;
    		}
    	}
    
    	protected virtual IEnumerator VInternalCoroutine( /*params*/ )
    	{
    		// write this just like a regular coroutine
    		Debug.LogFormat( "{0}.{1}", 
    		    		        GetType().Name, 
    		        		    System.Reflection.MethodBase.GetCurrentMethod().Name );
    		yield return null;
    	}
    }
    
    public class DerivedClass : BaseClass
    {
    	protected override IEnumerator VInternalCoroutine()
    	{
    		// write this just like a regular coroutine
    		Debug.LogFormat( "{0}.{1}", GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name );
    		yield return null;
    	}
    }
