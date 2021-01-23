    public class MyService : Service
    {
        public object Any(Request requestDto)
        {
            var altDto = new AltRequest { Id = requestDto.Id };
            var response = HostContext.ServiceController.Execute(altDto, base.Request);
            //...
        }
    }
