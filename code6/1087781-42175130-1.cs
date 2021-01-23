    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    namespace NNG.NCPML.Api.Models{
        //[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
        public class SalesTargetDetail{
            public int SalesTargetDetailId{get; set;}
            public string SalesTargetId{get; set;}
            public int ItemInfoId{get; set;}
            public string ItemName{get; set;}
        }
    }
