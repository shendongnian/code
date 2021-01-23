    using Resources = MyLocalization.IdentityResource;
 
    public class MyCustomPasswordValidator : Microsoft.AspNet.Identity.PasswordValidator
    {
	
	
	    /// <summary>
        /// Ensures that the string is of the required length and meets the configured requirements
        /// 
        /// </summary>
        /// <param name="item"/>
        /// <returns/>
        public override Task<IdentityResult> ValidateAsync(string item)
        {
			//BUG: CurrentUICulture is not set correctly https://aspnetidentity.codeplex.com/workitem/2060
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            if (item == null)
                throw new ArgumentNullException("item");
            List<string> list = new List<string>();
            if (string.IsNullOrWhiteSpace(item) || item.Length < this.RequiredLength)
                list.Add(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.PasswordTooShort, new object[1]
        {
          (object) this.RequiredLength
        }));
            if (this.RequireNonLetterOrDigit && Enumerable.All<char>((IEnumerable<char>)item, new Func<char, bool>(this.IsLetterOrDigit)))
                list.Add(Resources.PasswordRequireNonLetterOrDigit);
            if (this.RequireDigit && Enumerable.All<char>((IEnumerable<char>)item, (Func<char, bool>)(c => !this.IsDigit(c))))
                list.Add(Resources.PasswordRequireDigit);
            if (this.RequireLowercase && Enumerable.All<char>((IEnumerable<char>)item, (Func<char, bool>)(c => !this.IsLower(c))))
                list.Add(Resources.PasswordRequireLower);
            if (this.RequireUppercase && Enumerable.All<char>((IEnumerable<char>)item, (Func<char, bool>)(c => !this.IsUpper(c))))
                list.Add(Resources.PasswordRequireUpper);
            if (list.Count == 0)
                return Task.FromResult<IdentityResult>(IdentityResult.Success);
            return Task.FromResult<IdentityResult>(IdentityResult.Failed(new string[1]
      {
        string.Join(" ", (IEnumerable<string>) list)
      }));
        }
	
	}
`
