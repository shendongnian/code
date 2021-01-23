    namespace ABC.Web.Models.DomainModel
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Runtime.Serialization;
        public abstract partial class ClassA
        {
            // You _do_ want this serialized to the client and back
            // so remove the [IgnoreDataMember] atribute
            public virtual string ApplicationNumberAccessor
            {
                get
                {
                    return this.ApplicationNumber;
                } 
                set
                {
                    this.ApplicationNumber = value;
                }
            }
        }
    }
