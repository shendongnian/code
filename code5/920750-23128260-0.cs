    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class EGOScript : MonoBehaviour {
	public static List<string> cardDeckList = new List<string> {
		"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13",
		"14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26",};
	public GameObject theGameObject;
	float ff = 0f;
	public float addIT = 0.2f;
	int counter;
	public static int zOffset = 0;
	public static float zSelect = 26;
	public static int zSelectInt = 26;
	
	// Use this for initialization
	void Start () {
		counter = 0;
		zOffset = 26;
		print (cardDeckList.Count);
		for (int z = 0; z < 26; z++) {
			theGameObject = Resources.Load(cardDeckList[z]) as GameObject;
			theGameObject.transform.position =  new Vector3(0f + ff, 0f + ff, zOffset);
			theGameObject.renderer.sortingOrder = counter;
			Instantiate(theGameObject);
			ff = ff + addIT;
			counter++;
			zOffset--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			//RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			worldPoint.z = Camera.main.transform.position.z;
			Ray ray = new Ray( worldPoint, new Vector3( 0, 0, 1 ) );
			RaycastHit2D hit = Physics2D.GetRayIntersection( ray );
			zSelect++;
			zSelectInt++;
			
			if(hit.collider != null) {
				//print (hit.collider.tag);
				//zSelect = hit.collider.transform.position.z;
				Vector3 z3 = hit.collider.transform.position;
				z3.z = zSelect;
				hit.collider.transform.position = z3;
				hit.collider.renderer.sortingOrder = zSelectInt;
				print (hit.collider.transform.position + " + " + zSelectInt);
			}
		}
	}
    }
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class DragScript : MonoBehaviour {
	float x;
	float y;
	float z;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;
	}
	void OnMouseDrag() {
		// Control the drag of the sprite
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (x, y, EGOScript.zSelect));
	}
    }
