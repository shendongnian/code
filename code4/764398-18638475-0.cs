    /// <summary>
    /// Provides a dynamic Profile.
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        private readonly Lazy<DynamicProfile> _dProfile;
        protected ControllerBase()
        {
            _dProfile = new Lazy<DynamicProfile>(() => new DynamicProfile(base.Profile));
        }
        private sealed class DynamicProfile : DynamicObject
        {
            private readonly ProfileBase _profile;
            public DynamicProfile(ProfileBase profile)
            {
                _profile = profile;
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = _profile.GetPropertyValue(binder.Name);
                return true;
            }
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                _profile.SetPropertyValue(binder.Name, value);
                _profile.Save();
                return true;
            }
        }
        /// <summary>
        /// New dynamic profile, can now access the properties as though they are on the Profile,
        /// e.g. Profile.PostCode
        /// </summary>
        protected new dynamic Profile
        {
            get { return _dProfile.Value; }
        }
        /// <summary>
        /// Provides access to the original profile object.
        /// </summary>
        protected ProfileBase ProfileBase
        {
            get { return base.Profile; }
        }
    }
