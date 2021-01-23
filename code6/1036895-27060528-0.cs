    using UnityEngine;
    using System.Collections;
    public class BundleLoader : MonoBehaviour{
        public string url;
        public int version;
        public IEnumerator LoadBundle(){
            using(WWW www = WWW.LoadFromCacheOrDownload(url, version){
                yield return www;
                AssetBundle assetBundle = www.assetBundle;
                GameObject gameObject = assetBundle.mainAsset as GameObject;
                Instantiate(gameObject );
                assetBundle.Unload(false);
            }
        }
        void Start(){
            StartCoroutine(LoadBundle());
        }
    }
