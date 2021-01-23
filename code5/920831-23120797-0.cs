    /// <summary>
    /// Implements a ToString method on the target class that serializes the members to JSON.
    /// </summary>
    [Serializable]
    public class ImplementJsonToStringAspect : InstanceLevelAspect
    {
        #region Methods
        /// <summary>
        /// Provides an implementation of <see cref="System.Object.ToString"/> that serializes the instance's
        /// public members to JSON.
        /// </summary>
        /// <returns></returns>
        [IntroduceMember(OverrideAction=MemberOverrideAction.OverrideOrFail)]
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this.Instance);
        }
        #endregion
    }
