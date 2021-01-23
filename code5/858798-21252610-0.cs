    if (Input.GetKey(KeyCode.D)) 
    {
        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.z += 10;
        transform.rotation = Quaternion.Euler (newRotation);
    }    
    else if (Input.GetKey(KeyCode.A)) 
    {
        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.z -= 10;
        transform.rotation = Quaternion.Euler (newRotation);
    }
