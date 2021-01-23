    public interface ISecurityProvider
    {
        IConvertible Secure(IConvertible value);
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
        protected override void SecureSelf(ISecurityProvider provider)
        {
            if (!this.IsSecured)
            {
                base.SecureSelf(provider);
                this.Id = (int)provider.Secure((IConvertible)this.Id);
                this.Name = (string)provider.Secure((IConvertible)this.Name);
            }
        }
    }
