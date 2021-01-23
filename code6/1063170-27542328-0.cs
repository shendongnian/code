    public abstract class ViewModel : ObservableObject
    {
        ...
    }
    
    public abstract class ViewModel<TPrimaryModel> : ViewModel
        where TPrimaryModel : TwoNames, new()
    {
        ...
    }
