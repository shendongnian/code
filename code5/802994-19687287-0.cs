    public int SenderId { get; set; }
    [ForeignKey("SenderId")]
    public virtual User Sender { get; set; }
    public int ReceiverId { get; set; }
    [ForeignKey("ReceiverId")]
    public virtual User Receiver { get; set; }
