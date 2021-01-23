    private void SetQuaternions()
    {
        var rotationAxis = new Vector3D(-5f, 1f, 1f);
    
        RotationQuaternion = new Quaternion(rotationAxis, 65f);
        RotationQuaternion.Normalize();
        var q = RotationQuaternion;
        q.Conjugate();
        RotationQuaternionConjugate = q;
    
        if (!RotationQuaternion.IsNormalized)
        {
            RotationQuaternion.Normalize();
        }
        if (!RotationQuaternionConjugate.IsNormalized)
        {
            RotationQuaternionConjugate.Normalize();
        }
    }
