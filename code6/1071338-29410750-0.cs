    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
 
    public class HealthBar : MonoBehaviour {
        public float MaxHealth = 100;
        private float _playerHealth;
        private Image _greenBar
        void Start () {
                _playerHealth = MaxHealth;
                _greenBar = transform.FindChild("GreenBar").GetComponent<Image>();
        }
       
        void Update () {
                //logic to set _playerHealth goes here
                _greenBar.fillAmount = _playerHealth/MaxHealth;
        }
    }
