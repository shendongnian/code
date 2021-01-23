    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class cycleFlow : MonoBehaviour
    {
          
      private Color night;
      private Color day;
      private IEnumerable<SpriteRenderer> childSpriteRenderers;
          
      void Start ()
      {
        night = new Color(30, 30, 30);
        day = Color.white;
            
        childSpriteRenderers = transform.GetComponentsInChildren<SpriteRenderer> ();
      }
          
      void Update ()
      {
        DayNightCycle ();
      }
          
      void DayNightCycle ()
      {
        if (Input.GetKey (KeyCode.Q))
        {
          foreach (SpriteRenderer child in childSpriteRenderers)
          {
            child.color = Color.Lerp (child.color, night, Time.deltaTime);
          }
        }
        
        if (Input.GetKey (KeyCode.E))
        {   
          foreach (SpriteRenderer child in childSpriteRenderers)
          {
            child.color = Color.Lerp (child.color, day, Time.deltaTime);
          }
        }
      }
    }
