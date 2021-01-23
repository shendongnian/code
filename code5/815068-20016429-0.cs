    using System.Collections.Generic;
    using UnityEngine;
    
    public class TileMap : MonoBehaviour {
    
    	public int size_x = 100;
    	public int size_z = 50;
    	public float tileSize = 1.0f;
    
    	// Use this for initialization
    	void Start() {
    	}
    
    	void CreateMapLayer() {
    		GameObject mapLayerGO = new GameObject();
    		mapLayerGO.transform.parent = gameObject.transform;
    		MapLayer mapLayer = mapLayerGO.AddComponent<MapLayer>();
    		mapLayer.Initialize();
    	}
    }
