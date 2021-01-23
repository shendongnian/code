    using System;
    using AutoMapper;
    
    class Device
    {
        public string Name {get; set;}
    }
    
    class DeviceAccessToken
    {
        public Device Device {get; set;}
        public string Key {get; set;}
        public string Secret {get; set;}
    }
    
    class DeviceDto
    {
        public string DeviceName {get; set;}
        public string Key {get; set;}
        public string Secret {get; set;}
    }
    
    public class Program
    {
    	public void Main()
        {
    		 
    		// Configure AutoMapper
    		Mapper.CreateMap<DeviceAccessToken, DeviceDto>();		
    					
    		var dat = new DeviceAccessToken { Device = new Device { Name = "Dev Name" }, Key = "Key", Secret = "Secret" };
    		
    		var dto = Mapper.Map<DeviceDto>(dat);
    		
    		Console.WriteLine(dto.DeviceName);
    		Console.WriteLine(dto.Key);
    		Console.WriteLine(dto.Secret);
    	}
    }
