    frontLeftWheel.steerAngle = steerAngle.Adjusted();
...
    public static class Extensions
    {
        private const float MAX_VAL = 360.0;
        public static float AdjustedAngle(
            this Vector3 eulerAngle, int idx = 2)
        {
            /* idx 0 = x
                   1 = y
                   2 = z */
            //float axesVal = idx == 0 
            //    ? eulerAngle.x 
            //    : idx == 1 ? eulerAngle.y : eulerAngle.z;
            /* need to differentiate between a valid 359, 
               and an invalid 359, which should be returned as 
               359 - 360 or -1 */
            //var valid = <do some work>; 
            
            // return valid ? axesVal : axesVal - MAX_VAL;
        }
    }
