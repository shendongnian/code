    public interface ISecurityProvider
    {
        TSecurable Secure<TSecurable>(TSecurable value) where TSecurable : IConvertible;
    }
    
    public abstract class BaseEntity
    {
        protected bool IsSecured { get; set; }
    
        protected virtual void SecureSelf(ISecurityProvider provider)
        {
            if (!this.IsSecured)
            {
                this.IsSecured = true;
            }
        }
    }
    
    public class SomeDataRecord : BaseEntity
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        protected override void SecureSelf<TSecurable>(ISecurityProvider provider)
        {
            if (!this.IsSecured)
            {
                base.SecureSelf(provider);
                this.Id = provider.Secure(this.Id);
            }
        }
    }
