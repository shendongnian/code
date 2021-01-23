    using UnityEngine;
    using System.Collections;
    public class Vetrine : MonoBehaviour
    {
        public Texture2D textn;
        public GameObject[] pictures;
        public GameObject player;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            marker = GameObject.FindGameObjectsWithTag("infowindow");
            pictures = GameObject.FindGameObjectsWithTag("picture");
        }
        void MyFunction(GameObject picture, string name)
        {
            Texture2D tex = (Texture2D)Resources.Load(name, typeof(Texture2D));
            picture.renderer.material.mainTexture = tex;
        }
        void Update()
        {
            foreach (GameObject picture in pictures)
            {
                if (Vector3.Distance(picture.transform.position, player.transform.position) < 20)
                {
                    MyFunction(picture, picture.name);
                }
                else
                {
                    MyFunction(picture, "someOtherNameHere");
                }
            }
        }
    }
