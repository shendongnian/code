    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ClassLibrary1
    {
        public class SortableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>, ISortableCollection where T : ISortable, IComparable, IComparable<T>
        {
            public new void Add(T item)
            {
                if (this.Items.Contains(item))
                    throw new InvalidOperationException("This list can contain the same item only once");
                base.Add(item);
            }
    
            public void Sort()
            {
                var sorted = this.Items.ToList();
                sorted.Sort();
                for (var i = 0; i < this.Items.Count; i++)
                {
                    if (object.ReferenceEquals(this.Items[i], sorted[i]))
                    {
                        this.Items[i].Index = i;
                        continue;
                    }
                    // if u want to support duplicates create a nextIndexOf and start searching from i
                    var previousIndex = IndexOf(sorted[i]);
                    Move(previousIndex, i);
                }
            }
    
            protected override void InsertItem(int index, T item)
            {
                item.Index = index;
                item.ParentCollection = this;
                base.InsertItem(index, item);
            }
    
            protected override void RemoveItem(int index)
            {
                this.Items[index].ParentCollection = null;
                base.RemoveItem(index);
            }
    
            protected override void ClearItems()
            {
                foreach (var item in this.Items)
                    item.ParentCollection = null;
                base.ClearItems();
            }
    
            protected override void SetItem(int index, T item)
            {
                this.Items[index].ParentCollection = null;
                item.Index = index;
                item.ParentCollection = this;
                base.SetItem(index, item);
            }
    
            protected override void MoveItem(int oldIndex, int newIndex)
            {
                this.Items[oldIndex].Index = newIndex;
                this.Items[newIndex].Index = oldIndex;
                base.MoveItem(oldIndex, newIndex);
            }
        }
    
        public interface ISortableCollection : IList
        {
            void Sort();
        }
    
        public interface ISortable
        {
            Int32 Index { get; set; }
            ISortableCollection ParentCollection { get; set; }
        }
    
        public class BaseClass : ISortable, IComparable, IComparable<BaseClass>
        {
            public int Index { get; set; }
    
            public ISortableCollection ParentCollection { get; set; }
    
            public int CompareTo(object obj)
            {
                return CompareTo(obj as BaseClass);
            }
    
            public int CompareTo(BaseClass other)
            {
                if (other == null)
                    return 1;
                return this.Index.CompareTo(other.Index);
            }
        }
    
        public class DerivedClass : BaseClass { }
    
        public class Controller
        {
            SortableCollection<BaseClass> MyBaseSortableList = new SortableCollection<BaseClass>();
            SortableCollection<DerivedClass> MyDerivedSortableList = new SortableCollection<DerivedClass>();
    
            public Controller()
            {
                //do things
                MyDerivedSortableList.Add(new DerivedClass());
                MyDerivedSortableList.Add(new DerivedClass());
                var derivedThing = new DerivedClass();
                MyDerivedSortableList.Add(derivedThing);
                var sibiling = derivedThing.ParentCollection[derivedThing.Index - 1] as BaseClass;  //way easier
                // switch the two objects order and call sort
                // calling a sort before the operation if indexes have been messed with
                // add an event to ISortable to notify the list the index has been changed and mark the list dirty
                derivedThing.Index -= 1;
                sibiling.Index += 1;
                derivedThing.ParentCollection.Sort();   // maybe the list was created where i couldn't access it
            }
        }
    }
