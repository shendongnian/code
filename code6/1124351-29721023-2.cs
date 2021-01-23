       namespace x.Dto.Definitions
       {    
           [DataContract]
           public class AbcDto : DtoBase<AbcDto>
           {
               [DataMember]
               public string Property1 {get; set;}
               //...
           }
       }
