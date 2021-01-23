    using UnityEngine;
    using System.Collections.Generic;
    
    namespace de.softfun.drawntogether {
        public class EnhancedBehavior : MonoBehaviour {
            private List<GameObject> linkedObjects = new List<GameObject>();
    
            protected void destroy(params GameObject[] objects) {
                foreach (GameObject o in objects) {
                    try {
                        Destroy(o);
                    } catch {
                        continue;
                    }
                }
            }
    
            public void LinkObjects(params GameObject[] objects) {
                foreach (GameObject o in objects) {
                    linkedObjects.Add(o);
                }
            }
    
            void OnDestroy() {
                foreach (GameObject o in linkedObjects) {
                    destroy(o);
                }
            }
    
            protected T instantiate<T>(T prefab, bool addLink = true) where T : Object {
                T o =  (T)Instantiate(prefab);
    			if (addLink && (o is GameObject)) {
    				linkedObjects.add(o);
    			}
    			return o;
            }
    
        }
    }
