    if (Input.GetMouseButtonDown(0))
    {
        RaycastHit hit;
        if (Physics.RayCast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == collider)
            {
                //Do your thing.
            }
        }
    }
