    [DataContract]
    class Status
    {
          [DataMember(Name = "code")]
          public string code { get; set; }
          [DataMember(Name = "message")]
          public string message { get; set; }
    }
