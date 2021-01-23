    if (MustOrbit && !IsOrbited) {
    
            //Rotate all models around X,Y,Z axe
            if (cube != null)
                transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
                desiredPosition = (transform.position - center.position).normalized * radius + center.position;
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    
           // IsOrbited = true;
           // MustOrbit = false;
            }
