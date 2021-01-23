    using UnityEngine;
    using System.Collections;
    public class GameManager : MonoBehaviour
    {
	    public GameObject myObject;
	    void Start ()
        {
		    Instantiate(myObject, transform.position, transform.rotation);
	    }
    }
