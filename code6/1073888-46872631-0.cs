    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class FadeController : MonoBehaviour
    {
        public float fadeDuration = 0.5f;
        public float fadeDelay = 0f;
        public float fadeTo = 0f;
        public Text text;
        void Start ()
        {
            // Fade with initial delay
            Invoke ("fade", fadeDelay);
        }
        public void fade ()
        {
            // Fade in/out
            text.CrossFadeAlpha (fadeTo, fadeDuration, false);
        }
    }
