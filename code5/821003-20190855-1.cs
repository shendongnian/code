    // Type: Microsoft.Internal.Web.Utils.ExceptionHelper
    // Assembly: WebMatrix.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
    // MVID: 3F332B40-45DB-42E2-A4ED-0826DE223A79
    // Assembly location: C:\Windows\Microsoft.NET\assembly\GAC_MSIL\WebMatrix.Data\v4.0_1.0.0.0__31bf3856ad364e35\WebMatrix.Data.dll
    
    using System;
    
    namespace Microsoft.Internal.Web.Utils
    {
        internal static class ExceptionHelper
        {
            internal static ArgumentException CreateArgumentNullOrEmptyException(string paramName)
            {
                return new ArgumentException(CommonResources.Argument_Cannot_Be_Null_Or_Empty, paramName);
            }
        }
    }
