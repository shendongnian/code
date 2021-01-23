    public List<Transform> allObjectsInRange; // GameObjects to enclose into calculations, basically all which ever entered the sphere collider.
    public List<float> relatedDistances;
    
    void Update () {
        // basic loop to iterate through each object in range to update it's distance in the Lists IF YOU NEED...
        for (int cnt = 0; cnt < allObjectsInRange.Count; cnt++) {
            relatedDistances[cnt] = Vector2.Distance (transform.position, allObjectsInRange[cnt].position);
        }
    }
    
    // Add new entered Colliders (Walls, entities, .. all Objects with a collider on the same layer) to the watched ones
    void OnCollisionEnter (Collision col) {
        allObjectsInRange.Add (col.collider.transform);
        relatedDistances.Add (Vector2.Distance (transform.position,  col.collider.transform));
    }
    
    // And remove them if they are no longer in reasonable range
    void OnCollisionExit (Collision col) {
        if (allObjectsInRange.Contains (col.collider.transform)) {
            relatedDistances.RemoveAt (allObjectsInRange.IndexOf (col.collider.transform));
            allObjectsInRange.Remove (col.collider.transform);
        }
    }
