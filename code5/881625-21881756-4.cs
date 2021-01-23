    public static class ControlCollectionExt
    {
        public static Control FindByTag(this ControlCollection controls, string tag)
        {
            Control result = null;
            for (var ctrl in controls)
            {
                if (ctrl.Tag == tag)
                {
                    result = ctrl;
                    break;
                }
            }
            return result;
        }
    }
