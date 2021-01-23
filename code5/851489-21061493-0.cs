    public static float SlerpAngle(
        float currentAngle, float targetAngle, double t, float k)
    {
        // No time has passed, keep angle at current
        if (t == 0)
            return currentAngle;
        // Avoid unexpected large angles
        currentAngle = MathHelper.WrapAngle(currentAngle);
        targetAngle = MathHelper.WrapAngle(targetAngle);
        // Make sure the path between current -> target
        // is within the -pi -> pi range otherwise 
        // the 'long way round' will be calculated
        float difference = Math.Abs(currentAngle - targetAngle);
        if (difference > MathHelper.Pi)
        {
            if (currentAngle > targetAngle)
            {
                targetAngle += MathHelper.TwoPi;
            }
            else
            {
                currentAngle += MathHelper.TwoPi;
            }
        }
        // Quat.Slerp was outputing a close-to-0 value 
        // when bt was in the range (-pi, 0), ensuring
        // positivity, halfing difference between a0 / bt
        // and then doubling result before output solves this. 
        currentAngle += MathHelper.TwoPi;
        targetAngle += MathHelper.TwoPi;
        currentAngle /= 2;
        targetAngle /= 2;
        // Calculate spherical interpolation
        Quaternion qCurrent = Quaternion.CreateFromAxisAngle(
            Vector3.UnitZ, currentAngle);
        Quaternion qTarget = Quaternion.CreateFromAxisAngle(
            Vector3.UnitZ, targetAngle);
        Quaternion qResult = Quaternion.Slerp(
            qCurrent, qTarget, (float)(1 - Math.Exp(-k * t)));
        // Double value as above
        float value = 2 * 2 * (float)Math.Acos(qResult.W);
        return value;
    }
