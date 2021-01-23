        using UnityEngine; using System.Collections;
    
    public class apiManager : MonoBehaviour
    
    {
    
    public string url = "URL";
    
     public string temp;
    
     public void Start(){
         StartCoroutine (WaitForRequest (w));
     }
     IEnumerator WaitForRequest(){
         WWW w = new WWW (url);
         yield return w;
         temp = w.text.ToString ();
     }
     public string getTemp(){
         return temp;
     }
    
    }
