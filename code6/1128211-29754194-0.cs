    /// <summary>
    /// Gets the 3D position of where the mouse cursor is pointing on a 3D plane that is
    /// on the axis of front/back and up/down of this transform.
    /// Throws an UnityException when the mouse is not pointing towards the plane.
    /// </summary>
    /// <returns>The 3d mouse position</returns>
    Vector3 GetMousePositionInPlaneOfLauncher () {
        Plane p = new Plane(transform.right, transform.position);
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        float d;
        if(p.Raycast(r, out d)) {
            Vector3 v = r.GetPoint(d);
            return v;
        }
    
        throw new UnityException("Mouse position ray not intersecting launcher plane");
    }
