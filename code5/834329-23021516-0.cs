    using UnityEngine;
    using System.Collections;
    public class Example : MonoBehaviour {
      void OnCollisionEnter(Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2){
            audio.Play();        
        }
      }
    }
