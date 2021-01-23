        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public class TrackControlAttribute : Attribute
        {
            public readonly Type ControlType;
            public TrackControlAttribute(Type controlType)
            {
                ControlType = controlType;
            }
        }
        [TrackControl(typeof(ShotTrackControl))]
        public class ShotTrack
        {
            ...
        }
