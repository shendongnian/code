    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    
    namespace ConsoleApp4
    {
      using static Console;
    
      public class SortableObservableCollection<T> : ObservableCollection<T>
      {
        public Func<T, object> SortingSelector { get; set; }
    
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
          base.OnCollectionChanged(e);
          if (SortingSelector != null)
          {
            var map = this
              .Select((item, index) => (Item: item, Index: index))
              .OrderBy(tuple => SortingSelector(tuple.Item))
              .Select((tuple, index) => (OldIndex: tuple.Index, NewIndex: index))
              .Where(o => o.OldIndex != o.NewIndex);
    
            if (map.Any())
            {
              var first = map.FirstOrDefault();
              Move(first.OldIndex, first.NewIndex);
            }
          }
        }
      }
    
    
      class Program
      {
        static void Main(string[] args)
        {
          var xx = new SortableObservableCollection<int>() { SortingSelector = i => i };
          xx.CollectionChanged += (sender, e) =>
           WriteLine($"action: {e.Action}, oldIndex:{e.OldStartingIndex},"
             + " newIndex:{e.NewStartingIndex}, newValue: {xx[e.NewStartingIndex]}");
    
          xx.Add(10);
          xx.Add(8);
          xx.Add(45);
          xx.Add(0);
          xx.Add(100);
          xx.Add(-800);
          xx.Add(4857);
          xx.Add(-1);
    
          foreach (var item in xx)
            Write($"{item}, ");
        }
      }
    }
