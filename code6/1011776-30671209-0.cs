    public class abstract BaseModel
    {
       private static readonly Hashids __hashId = new Hashids("seed", 2);
       public Id { get; set; }
       
       [NotMapped]
       public HashId
       {
         get { return BaseModel.__hashId.Encode(this.Id); }
       }
    }
