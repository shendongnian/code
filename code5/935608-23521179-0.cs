        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            var varyString = string.Empty;
            if(context.User.Identity.IsAuthenticated)
            {
                varyString += context.User.Identity.Name;
            }
            return varyString;
        }
