    public static explicit operator MyUtil.Message(MyWeb.MyWebService.Message other)
    {
          return new MyUtil.Message
          {
              Key = other.Key,
              Message = other.Message,
              Value = other.Message
          };
    }
