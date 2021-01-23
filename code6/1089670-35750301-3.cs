    // Copyright (c) .NET Foundation. All rights reserved.
    // Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
    
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    
    namespace Microsoft.AspNetCore.Mvc.ApiExplorer
    {
        public class ApiDescription
        {
            public string GroupName { get; set; }
            public string HttpMethod { get; set; }
            public IList<ApiParameterDescription> ParameterDescriptions { get; } = new List<ApiParameterDescription>();
            public IDictionary<object, object> Properties { get; } = new Dictionary<object, object>();
            public string RelativePath { get; set; }
            public ModelMetadata ResponseModelMetadata { get; set; }
            public Type ResponseType { get; set; }
            public IList<ApiRequestFormat> SupportedRequestFormats { get; } = new List<ApiRequestFormat>();
            public IList<ApiResponseFormat> SupportedResponseFormats { get; } = new List<ApiResponseFormat>();
        }
    }
