    namespace x.Response
    {
         [DataContract]
         public class BlockDataResponse<T> : ResponseBase
         {
                [DataMember]
                public IList<T> DataList { get; set; }
         }
    }
