    float minRotation = 0f;
    float maxRotation = 90f;
    float rotationSpeed = 40f; //degrees per second
    //get current rotation, seeing as you're making a sprite game
    // i'm assuming camera facing forward along positive z axis
    Vector3 currentEuler = transform.rotation.eulerAngles;
    float rotation = currentEuler.z;
    //increment rotation via inputs
    if (Input.GetKey(KeyCode.UpArrow)){
        rotation += rotationSpeed * Time.deltaTime;
    }
    else if (Input.GetKey(KeyCode.DownArrow)){
        rotation -= rotationSpeed * Time.deltaTime;
    }
    //clamp rotation to your min/max
    rotation = Mathf.Clamp(rotation, minRotation, maxRotation );
    //set rotation back onto transform
    transform.rotation = Quaternion.Euler( new Vector3(currentEuler.x, currentEuler.y, rotation));
