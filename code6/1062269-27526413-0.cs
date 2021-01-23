        using UnityEngine;
        using System.Collections;
    
        public class BundleTest : MonoBehaviour {
    
    	  void Start () {
    		StartCoroutine(StartCo());	
    	  }
    	
    	  IEnumerator StartCo() {
    		string url = "file://c:\\temp\\marble.unity3d";
    		WWW www = new WWW(url);
    		yield return www;
    		
    		AssetBundle bundle = www.assetBundle;
    		AssetBundleRequest request = bundle.LoadAsync ("marble", typeof(GameObject));
    		yield return request;
    
    		Debug.Log ("loaded asset: " + request.asset.ToString());
    		GameObject prefab = request.asset as GameObject;
    
    		GameObject go = (GameObject)Instantiate(prefab);
    		bundle.Unload(false);
    		www.Dispose();
    	  }
        }
