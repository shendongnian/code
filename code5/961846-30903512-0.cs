    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    public static string SerializeStaticClass(System.Type a_Type)
    {
            var TypeBlob = a_Type.GetFields().ToDictionary(x => x.Name, x => x.GetValue(null));
            return JsonConvert.SerializeObject(TypeBlob);
    }
