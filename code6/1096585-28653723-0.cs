	using UnityEngine;
	using System.Collections;
	
	public class RenderToTexture : MonoBehaviour {
	
		public Material mat;
		[HideInInspector]
		public Texture2D renderedTexture;
	
		void Start () {
			renderedTexture = new Texture2D(300, 300);
			mat.mainTexture = renderedTexture;
		}
		
		void OnPostRender(){
			renderedTexture.ReadPixels(new Rect((camera.pixelWidth - 300) / 2, (camera.pixelHeight - 300) / 2, camera.pixelWidth, camera.pixelHeight), 0, 0, false);
			renderedTexture.Apply();
		}
	}
