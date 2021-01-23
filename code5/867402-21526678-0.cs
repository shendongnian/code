    public interface IVisitor<T>
    {
        T Visit(IIntellectualRights bus);
        T Visit(IRetailBusiness bus);
    }
    public interface IBusiness
    {
        T Accept<T>(IVisitor<T> visitor);
    }
    public class AudioCDShop : EntityBaseClass, IRetailBusiness
    {
         public void Accept(IVisitor visitor)
         {
              return visitor.Visit(this);
         }
    //do the same for each IBusiness implementor.
