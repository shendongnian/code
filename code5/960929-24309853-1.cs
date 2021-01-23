    using System.Collections.ObjectModel;
    namespace Merlinia.CommonClasses
    {
       public abstract class JustTestingBase<TItem> : KeyedCollection<string, TItem>
       {
          internal JustTestingBase()
          {
            // so that other assemblies cannot misuse this as their own base class
          }
          protected override string GetKeyForItem(TItem anItem)
          {
             return GetKeyForItemHelper(anItem).ToUpperInvariant();
          }
          internal abstract string GetKeyForItemHelper(TItem anItem);
       }
       public abstract class JustTesting<TItem> : JustTestingBase<TItem>
       {
          protected new abstract string GetKeyForItem(TItem anItem);
          internal override string GetKeyForItemHelper(TItem anItem)
          {
            return GetKeyForItem(anItem);
          }
       }
    }
