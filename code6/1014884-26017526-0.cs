     foreach (View_rx rx in rxs)
     {
        StringByColumnViewModel svm = new StringByColumnViewModel(stuff,
                        stringByColViewModel, presenterViewModel => {
                            var oldPos = this.Strings.IndexOf(stringByColViewModel);  <--This is wrong
                            this.Strings.RemoveAt(oldPos);
                            this.Strings.Insert(oldPos, ???);
                        });
    
       Strings.Add(svm);                                       
     }
     public class StringByColumnViewModel
     {
         public StringByColumnViewModel(Action<StringByColumnViewModelBase> onEdit) : base(onEdit)
         }
     }
