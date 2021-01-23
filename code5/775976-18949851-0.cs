    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NTier.Web.Core.Interfaces.Common;
    using NTier.Web.Core.Interfaces.DataModels;
    using NTier.Web.Core.Interfaces.Stores;
    
    
    namespace NTier.Web.DataAccess.Entities
    {
    	public sealed class MemberEntity : IdentityUser<Guid, MemberLogin, MemberRole, MemberClaim>,
    		IMemberDataModel, IAuditable
    	{
    	
    		public MemberEntity()
    		{
    			Id = Guid.NewGuid();
    		}
    
    		#region Overrides of IdentityUser<Guid,MemberLogin,MemberRole,MemberClaim>
    
    		public override Guid Id
    		{
    			get { return base.Id; }
    			set
    			{
    				base.Id = value != Guid.Empty ? value : base.Id;
    			}
    		}
    
    		#region Overrides of IdentityUser<Guid,MemberLogin,MemberRole,MemberClaim>
    
    		public override string PasswordHash
    		{
    			get { return base.PasswordHash; }
    			set
    			{
    				base.PasswordHash = !string.IsNullOrWhiteSpace(value) ? value : base.PasswordHash ;
    			}
    		}
    
    		#endregion
    
    		#endregion
    
    		public Guid Identity
    		{
    			get { return Id; }
    			set
    			{
    				if (value != Guid.Empty)
    				{
    					Id = value;
    				}
    			}
    		}
    
    
    		public string Moniker { get; set; }
    
    		[MaxLength(256)]
    		public string FirstName { get; set; }
    		[MaxLength(256)]
    		public string LastName { get; set; }
    		[MaxLength(256)]
    		public string Middle { get; set; }
    
    		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MemberEntity, Guid> manager)
    		{
    			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    			// Add custom user claims here
    			return userIdentity;
    		}
    
    		#region Implementation of IAuditable
    		public DateTime DateTimeCreated { get; set; }
    		public DateTime? DateTimeModified { get; set; }
    		public DateTime? DateTimeDeleted { get; set; }
    		public DateTime? DateTimeArchived { get; set; }
    		public string CreatedBy { get; set; }
    		public string ModifiedBy { get; set; }
    		public string DeletedBy { get; set; }
    		public string ArchivedBy { get; set; }
    		public bool IsDeleted { get; set; }
    		public bool IsArchived { get; set; }
    		#endregion
    	}
    }
