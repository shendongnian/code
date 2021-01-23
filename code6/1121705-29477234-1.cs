    frontLeftWheel.steerAngle =
        steerAngle.Adjusted(steering.transform.eulerAngles.z);
...
    public static class Extensions
    {
        private const float MAX_VAL = 360.0;
        public static float AdjustedAngle(
            this EulerAngle eulerAngle, float axesVal)
        {
            //if (some condition i don't know) {
            //    return axesVal - MAX_VAL; 
            //}
            //return axesVal;
        }
    }
