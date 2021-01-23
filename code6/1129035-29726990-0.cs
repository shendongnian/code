    using UnityEngine;
	using System.Collections;
	public class SpawnStar : MonoBehaviour {
		public GameObject StarPrefab;
		public bool InstantiateStar = false;
		void Update () {
			if (InstantiateStar) {
				GameObject starClone = (GameObject)Instantiate (StarPrefab);
				float r = Random.Range (0f, 1f);
				float g = Random.Range (0f, 1f);
				float b = Random.Range (0f, 1f);
				float a = Random.Range (0f, 1f);
				starClone.renderer.material.color = new Color (r, g, b, a);
				InstantiateStar = false;
			}
		}
	}
