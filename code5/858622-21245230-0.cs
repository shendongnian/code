    class WrapperXYZ
    {
        XYZ xyz;
        public override bool Equals(object other)
        {
            if(other is typeof(XYZ))
            {
                // check the contents
            }
            else
            {
                return false;
            }
        }
        // TODO: write a hash method if you are using a dictionary
    }
