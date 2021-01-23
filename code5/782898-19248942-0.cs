    public interface ISelectFoo {    
        IEnumerable<SelectListItem> FooDdl { get; set; }
    }
    public class FooModel:ISelectFoo {  /* implementation */ }     
    public static void PopulateFoo(this ISelectFoo data, FooRepository repo)
    {
        data.FooDdl = repo.GetAll().ToSelectList(x => x.Id, x => x.Name);
    }
    
    //controller
    var model=new ViewModel(); 
    model.PopulateFoo(repo);
     //a wild idea
    public static T CreateModel<T>(this FooRepository repo) where T:ISelectFoo,new()
    {
        var model=new T();
        model.FooDdl=repo.GetAll().ToSelectList(x => x.Id, x => x.Name);
        return model;
     }
    //controller
     var model=fooRepository.Create<MyFooModel>();
