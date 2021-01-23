    frontLeftWheel.steerAngle =
        steerAngle.Adjusted(steering.transform.eulerAngles.z);
...
    public static class Extensions
    {
        private const int MAX_VAL = 360;
        public static int AdjustedAngle(
            this EulerAngle eulerAngle, int axesVal)
        {
            //if (some condition i don't know) {
            //    return axesVal - MAX_VAL; 
            //}
            //return axesVal;
        }
    }
