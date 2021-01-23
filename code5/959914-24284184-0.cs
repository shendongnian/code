    [DataContract]
    Public Class UserUpdateDto : UserDto {
    
        [DataMember]
        public new string EmailAddress;
    }
    void Update(UserUpdateDto  request);
