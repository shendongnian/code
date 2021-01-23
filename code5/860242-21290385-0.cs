    public class Device
    {
        public Device(string status)
        {
            Status = status;
        }
        public string Status { get; set; }
        public void SetStatus(string value)
        {
            Status = value;
        }
        public string GetStatus()
        {
            return Status;
        }
    }
    public class Light : Device
    {
        public Light(string status) : base(status)
        {
        }
    }
    public class ColoredLight : Light
    {
        public ColoredLight(string status) : base(status)
        {
        }
    }
