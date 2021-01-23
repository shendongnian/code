    public class DealsUserVM : BaseViewModel
    {
        private readonly IDealsUser _dealsUser;
        public DealsUserVM()
        	: this(new DealsUser())
        {
        	// Empty ctor
        }
        public DealsUserVM(IDealsUser dealsUser)
        {
            _dealsUser = dealsUser;
        }
        public IDealsUser Model
        {
            get
            {
                return _dealsUser;
            }
        }
        public string Username
        {
            get { return _dealsUser.Username; }
            set
            {
                SetModelProperty(_dealsUser.Username, value,
                    () => { _dealsUser.Username = value; });
            }
        }
        public bool IsAdministrator
        {
            get { return _dealsUser.IsAdministrator; }
            set
            {
                SetModelProperty(_dealsUser.IsAdministrator, value,
                    () => { _dealsUser.IsAdministrator = value; });
            }
        }
        public bool IsPlanModerator
        {
            get { return _dealsUser.IsPlanModerator; }
            set
            {
                // If IsPlanModerator has changed (and was updated as a result)
                if (SetModelProperty(_dealsUser.IsPlanModerator, value,
                    () => { _dealsUser.IsPlanModerator = value; }))
                {
                    // If IsPlanModerator is now TRUE
                    if (value)
                    {
                        this.IsPlanner = true;
                    }
                }
            }
        }
        public bool IsPlanner
        {
            get { return _dealsUser.IsPlanner; }
            set
            {
                // If IsPlanner has changed (and was updated as a result)
                if (SetModelProperty(_dealsUser.IsPlanner, value,
                        () => { _dealsUser.IsPlanner = value; }))
                {
                    // If IsPlanner is now FALSE
                    if (!value)
                    {
                        this.IsPlanModerator = false;
                    }
                }
            }
        }
        public string EmailAddress
        {
            get { return _dealsUser.EmailAddress; }
            set
            {
                SetModelProperty(_dealsUser.EmailAddress, value,
                    () => { _dealsUser.EmailAddress = value; });
            }
        }
        public override string ToString()
        {
            return _dealsUser.ToString();
        }
    }
