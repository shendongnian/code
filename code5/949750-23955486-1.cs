    public interface ISecurityProvider<TSecurable>
    where TSecurable : IConvertible // to constrain to struct types AND string
    {
        TSecurable Secure(TSecurable value);
    }
    public abstract class BaseEntity<TSecurable> where TSecurable : IConvertible
    {
        protected bool IsSecured { get; set; }
        protected virtual void SecureSelf(ISecurityProvider<TSecurable> provider)
        {
            if (!this.IsSecured)
            {
                this.IsSecured = true;
            }
        }
    }
    public class SomeDataRecord : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        protected override void SecureSelf(ISecurityProvider<int> provider)
        {
            if (!this.IsSecured)
            {
                base.SecureSelf(provider);
                this.Id = provider.Secure(this.Id); // COMPILER ERROR
            }
        }
    }
