    public class Member : Customer
    {
        private memberRegistrationDate = DateTime.Now;
        private membershipStatus = MembershipStatusEnum.Active;
        public virtual string MemberId { get; set; }
        public virtual string MemberRegistrationDate 
        { 
          get { return this.memberRegistrationDate; }; 
          set { this.memberRegistrationDate = value; }; 
        }
        public virtual string MembershipStatus 
        { 
          get { return this.membershipStatus; }; 
          set { this.membershipStatus = value; }; 
        }
    }
