    public class SomeViewModelOrDomainClass
    {
      public ICommand DoItCommand {get; private set;}
    
      //ctor
      public SomeViewModelOrDomainClass()
      {
        // if your command includes a CanExecute bool, then also demand a Predicate to handle CanExecute
        this.DoItCommand = new RelayCommand(() => this.SomePrivateMethod(maybeEvenAnEnclosedParam), aCanExecutePredicate);
      }
    }
