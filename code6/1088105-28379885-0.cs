    using UnityEngine;
    using System.Collections;
    
    public class CameraRunner : MonoBehaviour {
    public GameObject player;
    
      void Start () {
        if (player == null)
          player = GameObject.FindWithTag("Player");
      }
    
      void FixedUpdate () {
        if (player != null)
        transform.position = new Vector3 (0, player.transform.position.y + 9f, -10);
      }
    
    }
