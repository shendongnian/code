    namespace Provider1
    {
       [DataContract]
       public class Data
       {
          [DataMember]
          public int DataID { get; set; }
          [DataMember]
          public DateTime Time { get; set; }
       }
    }
 
    namespace Provider2
    {
       [DataContract]
       public class Data
       {
          [DataMember]
          public int ID { get; set; }
          [DataMember]
          public DateTime DATE { get; set; }
       }
    }
 
    namespace Internal
    {
       public class Data
       {
          public int id { get; set; }
          public DateTime d_time { get; set; }
       }
    } 
    
    public static class Configuration
    {
       public static void InitMappers()
       {
          AutoMapper.Mapper.CreateMap<Internal.Data, Provider1.Data>()
             .ForMember(x=> x.DataID, opt=> opt.MapFrom(src=> src.id))
             .ForMember(x=> x.Time, opt=> opt.MapFrom(src => src.d_time)); 
         AutoMapper.Mapper.CreateMap<Internal.Data, Provider2.Data> ()
            .ForMember (x => x.ID, opt => opt.MapFrom (src => src.id))
            .ForMember (x => x.DATE, opt => opt.MapFrom (src => src.d_time));
       }
    }
 
    public class TestExample
    {
       public void Test()
       {
          var src = new Internal.Data ();
          var dest = AutoMapper.Mapper.Map<Provider1.Data> (src);
          var dest2 = AutoMapper.Mapper.Map<Provider2.Data> (dest);
       }
    }
