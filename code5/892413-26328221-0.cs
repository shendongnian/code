    class CustomResolver : Microsoft.AspNet.SignalR.Hubs.DefaultParameterResolver
    {
        public override object ResolveParameter( Microsoft.AspNet.SignalR.Hubs.ParameterDescriptor descriptor, Microsoft.AspNet.SignalR.Json.IJsonValue value )
        {
            if( descriptor.ParameterType.IsInterface )
            {
                object TargetObject = <Create the object instance here>
                return value.ConvertTo( TargetObject.GetType() );
            }
            else
            {
                return value.ConvertTo( descriptor.ParameterType );
            }
        }
    }
