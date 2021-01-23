    using UnityEngine;
    using System.Collections;
    public class MainCamera: MonoBehaviour {
      void Start () {
        Debug.Log ("About to StartCoroutine");
        StartCoroutine(TestCoroutine());
        Debug.Log ("Back from StartCoroutine");
      }
      IEnumerator TestCoroutine(){
        Debug.Log ("about to yield return WaitForSeconds(1)");
        yield return new WaitForSeconds(1);
        Debug.Log ("Just waited 1 second");
        yield return new WaitForSeconds(1);
        Debug.Log ("Just waited another second");
        yield break;
        Debug.Log ("You'll never see this"); // produces a dead code warning
      }
    }
