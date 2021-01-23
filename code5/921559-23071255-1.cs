    using UnityEngine;
    using System.Collections;
    // we resolved classes names collision :)
    // we won't "using" whole SpriteFactory namespace because
    // both UnityEngine and SpriteFactory has got class named same "Sprite"
    // so we pull out only needed class
    using FactorySprite = SpriteFactory.Sprite;
    public class Running : MonoBehaviour {
       // you forgot to set name of variable representing your sprite
       private FactorySprite sprite;
    
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
