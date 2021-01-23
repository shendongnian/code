        public static void AddEnumClaim<T>(this ClaimsIdentity identity, String type, T enumvalue)
                where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("AddEnumClaim must be an enum");
            identity.AddClaim(new Claim(type, enumvalue.ToString()));
        }
