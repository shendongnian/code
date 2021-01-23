    [Key, Column(Order = 1)]
    [ForeignKey("User"), InverseProperty("Associations")]
    public int UserID { get; set; }
    [Key, Column(Order = 2)]
    [ForeignKey("Friend"), InverseProperty("Associations")]
    public int FriendID { get; set; }
