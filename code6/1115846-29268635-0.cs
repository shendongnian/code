        public override string GetVaryByCustomString(HttpContext Context, string Custom)
                {
    
                    //Here you set any cache invalidation policy
        
                    if (Custom == "hostname")
                    {
                        return Context.Request.Url.Host;
                    }
        
                    return base.GetVaryByCustomString(Context, Custom);
                }
