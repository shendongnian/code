    public class ApplicationUser : IdentityUser
    {        
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDay { get; set; }
        public int BirthPlace { get; set; }
        public int TeamId { get; set; }
        public int AvatarId { get; set; }
        public string Address { get; set; }        
        public DateTime RegisterationDate { get; set; }        
        public DateTime CodeSendDate { get; set; }
        public string ActivationCode { get; set; }
        public string PasswordResetToken { get; set; }
        public string FacebookAvatar { get; set; }
        public string FacebookId { get; set; }
        public bool UseFacebookAvatar { get; set; }
        public string IpAddress { get; set; }        
    
        public virtual Avatar Avatar { get; set; }
        
        
        public ApplicationUser()
        {
            this.Coupons = new HashSet<Coupon>();
        }
    
        [IgnoreDataMember]
        public virtual ICollection<Coupon> Coupons { get; set; }
    }
