    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
        
    [RequireComponent(typeof(AudioSource))]
    public class ToggleAudioClips : MonoBehaviour
    {        
        public AudioClip otherClip;
        
        bool stopPlaying = false;
        AudioClip currentClip;
        AudioClip nextClip;
        
        void Start () {
            currentClip = audio.clip;
            nextClip = otherClip;
            StartCoroutine (PlayClip ());
        }
    
        IEnumerator PlayClip () {
            audio.clip = currentClip;
            audio.Play ();
            yield return new WaitForSeconds(audio.clip.length);
            if (!stopPlaying) {
                AudioClip c = nextClip;
                nextClip = currentClip;
                currentClip = c;
                StartCoroutine (PlayClip ());
            }
        }
        public bool StopPlaying () {
            stopPlaying = true;
            audio.Stop ();
        }
    }
