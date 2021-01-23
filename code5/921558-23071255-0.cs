    using UnityEngine;
    using System.Collections;
    using SpriteFactory;
    public class Running : MonoBehaviour {
       // you forgot to set name of variable representing your sprite
       private SpriteFactory.Sprite sprite;
    
       // Use this for initialization
       void Start () {
          sprite = GetComponent<Sprite> ();
       }
    
      // Update is called once per frame
      void Update () {
         if(Input.GetKey(KeyCode.RightArrow)) {
            Sprite.Play("Run");
            Vector3 pos = transform.position;
            pos.x += Time.deltaTime * 2;
            transform.position = pos;
         }
         else{
            sprite.Stop();
         }
      }
    }
