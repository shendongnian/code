       JavaScriptSerializer js = new JavaScriptSerializer();
       var Data = DeserializeFromJson<RootObject>("Json String");
     public T DeserializeFromJson<T>(string json)
        {
            System.Web.Script.Serialization.JavaScriptSerializer ObjJSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            T deserializedProduct = ObjJSerializer.Deserialize<T>(json);
            return deserializedProduct;
        }
    public class Result
    {
    public string Id { get; set; }
    public string ModerationStatus { get; set; }
    public string LastModificationTime { get; set; }
    public bool IsRatingsOnly { get; set; }
    public int TotalCommentCount { get; set; }
    public int Rating { get; set; }
    public int RatingRange { get; set; }
    public bool IsRecommended { get; set; }
    public int TotalFeedbackCount { get; set; }
    public int TotalPositiveFeedbackCount { get; set; }
    public int TotalNegativeFeedbackCount { get; set; }
    public string DisplayLocale { get; set; }
    public string SubmissionTime { get; set; }
    public bool IsFeatured { get; set; }
    public string LastModeratedTime { get; set; }
    public string ProductId { get; set; }
    public string AuthorId { get; set; }
     }
      public class Brand
      {
    public string Id { get; set; }
    public string Name { get; set; }
      }
      public class __invalid_type__3240234
     {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BrandExternalId { get; set; }
    public Brand Brand { get; set; }
    public string CategoryId { get; set; }
    public string ProductPageUrl { get; set; }
       }
    public class Products
    {
    public __invalid_type__3240234 __invalid_name__3240234 { get; set; }
     }
     public class Z7knrbjunvi022pe4swqp18fra
    {
    public string Id { get; set; }
    public string ModerationStatus { get; set; }
    }
     public class Zsknvekklaxl56nzwliultz5mp
    { 
    public string Id { get; set; }
    public string ModerationStatus { get; set; }
    }
    public class Authors
    {
    public Z7knrbjunvi022pe4swqp18fra z7knrbjunvi022pe4swqp18fra { get; set; }
    public Zsknvekklaxl56nzwliultz5mp zsknvekklaxl56nzwliultz5mp { get; set; }
     }
     public class Includes
    {
    public Products Products { get; set; }
    public Authors Authors { get; set; }
    }
    public class RootObject
    {
    public List<Result> Results { get; set; }
    public Includes Includes { get; set; }
    public bool HasErrors { get; set; }
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int TotalResults { get; set; }
    }
