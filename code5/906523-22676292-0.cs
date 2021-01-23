    using UnityEngine;
    
    public class spriteAngler : MonoBehaviour
    {
        public Transform toFace;
        public SpriteRenderer toManipulate;
        public Sprite[] mySprites;
        private float theta;
        private Vector3 a;
        void Update()
        {
            toManipulate.sprite = mySprites[GetAngleIndex()];
        }
        int GetAngleIndex()
        {
            a = toFace.position - transform.position;
    
            a.Normalize();
            var b = transform.forward;
    
            theta = Mathf.Acos(Vector3.Dot(a, b)) * Mathf.Rad2Deg;
    
            if (a.x * a.z < 0)
                theta = 360.0f - theta;
    
            if (theta >= 292.5f && theta < 337.5f)
                return 7;
            else if (theta >= 22.5f && theta < 67.5f)
                return 1;
            else if (theta >= 67.5f && theta < 112.5f)
                return 2;
            else if (theta >= 112.5f && theta < 157.5f)
                return 3;
            else if (theta >= 157.5f && theta < 202.5f)
                return 4;
            else if (theta >= 202.5f && theta < 247.5f)
                return 5;
            else if (theta >= 247.5f && theta < 292.5f)
                return 6;
            else if (theta >= 337.5f || theta < 22.5f)
                return 0;
            else return 0;
        }
    
        private Rect guiPos = new Rect(0, 0, 720, 30);
        void OnGUI()
        {
            GUI.Label(guiPos, "Angle from the Player is: " + theta + " and forward=" + transform.forward + " and vectorToTarget=" + a);
        }
    }
