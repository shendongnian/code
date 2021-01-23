    public static Vector3 GetDestination ()
    {
            if (moveToDestination == Vector3.zero) 
            {
                RaycastHit hit;
                Ray r = Camera.mainCamera.ScreenPointToRay (Input.mousePosition);
                if (Physics.Raycast (r, out hit)) 
                {
                    while (!passables.Contains(hit.transform.gameobject.name))
                    {
                        if (!Physics.Raycast (hit.transform.position, r.direction, out hit))
                            break;
                        } // This seems like an unneeded }
                    }
                }
            }
            if(!hit.transform = null) 
            {
                moveToDestination = hit.point;
            }
        }
        return moveToDestination;
    }
