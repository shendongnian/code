     Public class PhoneNumber
      {
        public enum PhoneType
        { Work, Mobile, Home };
         public int id { get; set; }
         public string phoneNumber { get; set; }
         public PhoneType phoneType { get; set; }
         public virtual Person Person { get; set; }
      }
